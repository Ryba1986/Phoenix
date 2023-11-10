using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Reports.Queries;
using Phoenix.Services.Extensions;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Mappings;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Enums.Devices;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Reports.Queries
{
   internal sealed class GetPlcReportHandler : HandlerBase, IRequestHandler<GetPlcReportQuery, FileResult>
   {
      private readonly IIndex<PlcType, IPlcProcessor> _plcProcessors;
      private readonly IIndex<PlcReportType, ITypeProcessor> _typeProcessors;

      public GetPlcReportHandler(UnitOfWork uow, IIndex<PlcType, IPlcProcessor> plcProcessors, IIndex<PlcReportType, ITypeProcessor> typeProcessors) : base(uow)
      {
         _plcProcessors = plcProcessors;
         _typeProcessors = typeProcessors;
      }

      public async Task<FileResult> Handle(GetPlcReportQuery request, CancellationToken cancellationToken)
      {
         ITypeProcessor typeProcessor = _typeProcessors[request.Type];
         using ExcelPackage ep = ExcelExtensions.GetReportTemplate();

         ep.Workbook.Properties.Author = nameof(Phoenix);
         ep.Workbook.Properties.Created = DateTime.Now;

         IReadOnlyCollection<string> templateSheetNames = ep.Workbook.Worksheets
            .Select(x => x.Name)
            .ToArray();

         ep.Workbook.Worksheets.RemoveTemplateRows(typeProcessor.RemoveTemplateRowCount);
         await CreateSheetsAsync(ep.Workbook.Worksheets, request.Date, typeProcessor, cancellationToken);
         ep.Workbook.Worksheets.RemoveSheets(templateSheetNames);

         return new()
         {
            Name = typeProcessor.GetFileName(request.Date),
            Type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            Data = ep.GetAsByteArray(),
         };
      }

      private async Task CreateSheetsAsync(ExcelWorksheets sheets, DateOnly date, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         IReadOnlyCollection<DeviceReportDto> devices = await _uow.Device
            .AsNoTracking()
            .Include(x => x.Location)
            .Where(x =>
               x.IncludeReport &&
               x.Location.IncludeReport
            )
            .OrderBy(x => x.Location.Name)
            .ThenBy(x => x.ReportSequence)
            .Select(x => x.ToDeviceReportDto())
            .ToArrayAsync(cancellationToken);

         if (devices.Count == 0)
         {
            return;
         }

         CreateDeviceSheets(sheets, devices, typeProcessor);
         await FillDataAsync(sheets, devices, date, typeProcessor, cancellationToken);
         CreateResultSheets(sheets, devices, date, typeProcessor);
      }

      private void CreateDeviceSheets(ExcelWorksheets sheets, IReadOnlyCollection<DeviceReportDto> devices, ITypeProcessor typeProcessor)
      {
         foreach (DeviceReportDto device in devices)
         {
            ExcelWorksheet deviceSheet = sheets.Copy(_plcProcessors[device.PlcType].TemplateSheetName, device.Id.ToString());
            deviceSheet.Cells[typeProcessor.DeviceNameRow, 1].Value = device.Name;
         }
      }

      private async Task FillDataAsync(ExcelWorksheets sheets, IReadOnlyCollection<DeviceReportDto> devices, DateOnly date, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         IEnumerable<PlcType> plcTypes = devices
            .Select(x => x.PlcType)
            .Distinct();

         foreach (PlcType plcType in plcTypes)
         {
            await _plcProcessors[plcType].FillDataAsync(_uow, sheets, date, typeProcessor, cancellationToken);
         };
      }

      private static void CreateResultSheets(ExcelWorksheets sheets, IReadOnlyCollection<DeviceReportDto> devices, DateOnly date, ITypeProcessor typeProcessor)
      {
         foreach (IGrouping<string, DeviceReportDto> group in devices.GroupBy(x => x.LocationName))
         {
            ExcelWorksheet groupSheet = sheets.Copy(PlcHandlerHelper.BaseSheet, group.Key);

            foreach (DeviceReportDto device in group)
            {
               ExcelWorksheet deviceSheet = sheets[device.Id.ToString()];

               deviceSheet
                  .Cells[1, 1, deviceSheet.Dimension.Rows, deviceSheet.Dimension.Columns]
                  .Copy(groupSheet.Cells[1, groupSheet.Dimension.Columns + 1]);

               sheets.Delete(deviceSheet);
            }

            SetResultSheetHeaders(groupSheet, date, group.Key, typeProcessor);
         }
      }

      private static void SetResultSheetHeaders(ExcelWorksheet sheet, DateOnly date, string locationName, ITypeProcessor typeProcessor)
      {
         sheet.Cells[1, 1, 1, sheet.Dimension.Columns].Merge = true;
         sheet.Cells[typeProcessor.LegendRow, 1].Value = typeProcessor.GetLegend();

         ExcelRange headerCell = sheet.Cells[1, 1];
         headerCell.Value = typeProcessor.GetHeader(locationName, date);
         sheet.Select(headerCell);

         sheet.PrinterSettings.PrintArea = sheet.Cells[1, 1, sheet.Dimension.Rows, sheet.Dimension.Columns];
      }
   }
}
