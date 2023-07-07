using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Reports.Queries;
using Phoenix.Services.Extensions;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Enums.Devices;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Reports.Queries
{
   internal sealed class GetReportHandler : QueryHandlerBase, IRequestHandler<GetReportQuery, FileResult>
   {
      private readonly IIndex<PlcType, IPlcProcessor> _plcProcessors;
      private readonly IIndex<ReportType, ITypeProcessor> _typeProcessors;

      public GetReportHandler(UnitOfWork uow, IMapper mapper, IIndex<PlcType, IPlcProcessor> plcProcessors, IIndex<ReportType, ITypeProcessor> typeProcessors) : base(uow, mapper)
      {
         _plcProcessors = plcProcessors;
         _typeProcessors = typeProcessors;
      }

      public async Task<FileResult> Handle(GetReportQuery request, CancellationToken cancellationToken)
      {
         ITypeProcessor typeProcessor = _typeProcessors[request.Type];
         using ExcelPackage ep = ExcelExtensions.GetReportTemplate();

         ep.Workbook.Worksheets.RemoveTemplateRows(typeProcessor.RemoveTemplateRowCount);
         await CreateSheetsAsync(ep.Workbook.Worksheets, request, typeProcessor, cancellationToken);

         return new()
         {
            Name = typeProcessor.GetFileName(request.Date),
            Type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            Data = ep.GetAsByteArray(),
         };
      }

      private async Task CreateSheetsAsync(ExcelWorksheets sheets, GetReportQuery request, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         IReadOnlyCollection<DeviceReportDto> devices = await _uow.Device
            .AsNoTracking()
            .Include(x => x.Location)
            .Where(x =>
               x.IncludeReport &&
               x.Location.IncludeReport
            )
            .ProjectTo<DeviceReportDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

         if (devices.Count == 0)
         {
            return;
         }

         IEnumerable<Task> plcTasks = devices
            .GroupBy(x => x.PlcType)
            .Select(x => _plcProcessors[x.Key].FillDataAsync(sheets, request.Date, x.ToArray(), typeProcessor, cancellationToken));

         await Task.WhenAll(plcTasks);

         CreateResultSheets(sheets, request, devices, typeProcessor);
      }

      private static void CreateResultSheets(ExcelWorksheets sheets, GetReportQuery request, IReadOnlyCollection<DeviceReportDto> devices, ITypeProcessor typeProcessor)
      {
         IReadOnlyCollection<string> inputSheetNames = sheets
            .GetSheetNames()
            .ToArray();

         IEnumerable<IGrouping<string, DeviceReportDto>> locationGroups = devices
            .OrderBy(x => x.ReportSequence)
            .GroupBy(x => x.LocationName);

         foreach (IGrouping<string, DeviceReportDto> group in locationGroups)
         {
            ExcelWorksheet groupSheet = sheets.CloneSheet(PlcProcessorBase.BaseSheet, group.Key);
            foreach (DeviceReportDto device in group)
            {
               ExcelWorksheet deviceSheet = sheets[device.Id.ToString()];

               deviceSheet.Cells[1, 1, deviceSheet.Dimension.Rows, deviceSheet.Dimension.Columns]
                  .Copy(groupSheet.Cells[1, groupSheet.Dimension.Columns + 1]);
            }

            SetHeaders(groupSheet, request, group.Key, typeProcessor);
         }

         sheets.RemoveSheets(inputSheetNames);
      }

      private static void SetHeaders(ExcelWorksheet sheet, GetReportQuery request, string locationName, ITypeProcessor typeProcessor)
      {
         sheet.InsertRow(1, 2);
         sheet.Cells[1, 1, 1, sheet.Dimension.Columns].Merge = true;

         sheet.Row(1).Height = 21;
         sheet.Row(2).Height = 10;

         ExcelRange headerCell = sheet.Cells[1, 1];
         headerCell.Value = typeProcessor.GetHeader(locationName, request.Date);
         headerCell.Style.Font.SetFromFont("Arial CE", 14, true);
         headerCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
         headerCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
         sheet.Select(headerCell);

         sheet.Cells[3, 1].Value = typeProcessor.GetLegend();

         sheet.PrinterSettings.PrintArea = sheet.Cells[1, 1, sheet.Dimension.Rows, sheet.Dimension.Columns];
      }
   }
}
