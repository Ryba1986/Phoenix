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

         ep.Workbook.Properties.Author = nameof(Phoenix);

         IReadOnlyCollection<string> templateSheetNames = ep.Workbook.Worksheets
            .Select(x => x.Name)
            .ToArray();

         ep.Workbook.Worksheets.RemoveTemplateRows(typeProcessor.RemoveTemplateRowCount);
         await CreateSheetsAsync(ep.Workbook.Worksheets, request, typeProcessor, cancellationToken);

         ep.Workbook.Worksheets.RemoveSheets(templateSheetNames);

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
            .OrderBy(x => x.Location.Name)
            .ThenBy(x => x.ReportSequence)
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
         foreach (IGrouping<string, DeviceReportDto> group in devices.GroupBy(x => x.LocationName))
         {
            ExcelWorksheet groupSheet = sheets.Copy(PlcProcessorBase.BaseSheet, group.Key);
            foreach (DeviceReportDto device in group)
            {
               ExcelWorksheet deviceSheet = sheets[device.Id.ToString()];

               deviceSheet.Cells[1, 1, deviceSheet.Dimension.Rows, deviceSheet.Dimension.Columns]
                  .Copy(groupSheet.Cells[1, groupSheet.Dimension.Columns + 1]);

               sheets.Delete(deviceSheet);
            }

            SetHeaders(groupSheet, request, group.Key, typeProcessor);
         }
      }

      private static void SetHeaders(ExcelWorksheet sheet, GetReportQuery request, string locationName, ITypeProcessor typeProcessor)
      {
         sheet.Cells[1, 1, 1, sheet.Dimension.Columns].Merge = true;
         sheet.Cells[3, 1].Value = typeProcessor.GetLegend();

         ExcelRange headerCell = sheet.Cells[1, 1];
         headerCell.Value = typeProcessor.GetHeader(locationName, request.Date);
         sheet.Select(headerCell);

         sheet.PrinterSettings.PrintArea = sheet.Cells[1, 1, sheet.Dimension.Rows, sheet.Dimension.Columns];
      }
   }
}
