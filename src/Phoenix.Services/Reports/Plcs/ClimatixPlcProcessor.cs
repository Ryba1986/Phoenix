using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using OfficeOpenXml;
using Phoenix.Entities.Plcs.Climatixs;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Plcs.Climatixs.Dto;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Enums.Devices;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Reports.Plcs
{
   internal sealed class ClimatixPlcProcessor : PlcProcessorBase, IPlcProcessor
   {
      public ClimatixPlcProcessor(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task FillDataAsync(ExcelWorksheets sheets, DateOnly date, IReadOnlyCollection<DeviceReportDto> devices, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         IReadOnlyDictionary<int, ClimatixReportDto[]> plcData = await GetPlcDataAsync<Climatix, ClimatixReportDto>(_uow.Climatix, date, typeProcessor, cancellationToken);
         if (plcData.Count == 0)
         {
            return;
         }

         foreach (DeviceReportDto device in devices)
         {
            if (!plcData.TryGetValue(device.Id, out ClimatixReportDto[]? deviceData))
            {
               continue;
            }

            FillSheet(sheets[device.LocationName], device, deviceData, typeProcessor);
         }
      }

      private static void FillSheet(ExcelWorksheet sheet, DeviceReportDto device, IReadOnlyCollection<ClimatixReportDto> plcData, ITypeProcessor typeProcessor)
      {
         foreach (ClimatixReportDto climatix in plcData)
         {
            int rowIndex = typeProcessor.StartingPoints.Row + typeProcessor.GetDatePart(climatix.Date);

            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 0].Value = climatix.OutsideTempAvg.Round();
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 1].Value = climatix.OutsideTempMin;
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 2].Value = climatix.OutsideTempMax;

            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 3].Value = climatix.ChHighInletPresureAvg.Round();
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 4].Value = climatix.ChHighInletPresureMin;
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 5].Value = climatix.ChHighInletPresureMax;

            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 6].Value = climatix.ChHighOutletPresureAvg.Round();
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 7].Value = climatix.ChHighOutletPresureMin;
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 8].Value = climatix.ChHighOutletPresureMax;

            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 9].Value = climatix.Ch1LowInletTempAvg.Round();
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 10].Value = climatix.Ch1LowInletTempMin;
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 11].Value = climatix.Ch1LowInletTempMax;

            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 12].Value = climatix.Ch1LowOutletTempAvg.Round();
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 13].Value = climatix.Ch1LowOutletTempMin;
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 14].Value = climatix.Ch1LowOutletTempMax;

            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 15].Value = climatix.Ch1LowOutletPresureAvg.Round();
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 16].Value = climatix.Ch1LowOutletPresureMin;
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 17].Value = climatix.Ch1LowOutletPresureMax;

            if (device.DeviceType == DeviceType.DoubleHeating)
            {
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 18].Value = climatix.Ch2LowInletTempAvg.Round();
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 19].Value = climatix.Ch2LowInletTempMin;
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 20].Value = climatix.Ch2LowInletTempMax;

               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 21].Value = climatix.Ch2LowOutletTempAvg.Round();
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 22].Value = climatix.Ch2LowOutletTempMin;
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 23].Value = climatix.Ch2LowOutletTempMax;

               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 24].Value = climatix.Ch2LowOutletPresureAvg.Round();
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 25].Value = climatix.Ch2LowOutletPresureMin;
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 26].Value = climatix.Ch2LowOutletPresureMax;
            }

            if (device.DeviceType == DeviceType.HeatingDomestic)
            {
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 27].Value = climatix.DhwTempAvg.Round();
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 28].Value = climatix.DhwTempMin;
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 29].Value = climatix.DhwTempMax;
            }

            int summaryRowIndex = typeProcessor.StartingPoints.Row + typeProcessor.SummaryRowOffset;

            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 0].Value = plcData.Average(x => x.OutsideTempAvg).Round();
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 1].Value = plcData.Min(x => x.OutsideTempMin);
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 2].Value = plcData.Max(x => x.OutsideTempMax);

            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 3].Value = plcData.Average(x => x.ChHighInletPresureAvg).Round();
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 4].Value = plcData.Min(x => x.ChHighInletPresureMin);
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 5].Value = plcData.Max(x => x.ChHighInletPresureMax);

            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 6].Value = plcData.Average(x => x.ChHighOutletPresureAvg).Round();
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 7].Value = plcData.Min(x => x.ChHighOutletPresureMin);
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 8].Value = plcData.Max(x => x.ChHighOutletPresureMax);

            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 9].Value = plcData.Average(x => x.Ch1LowInletTempAvg).Round();
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 10].Value = plcData.Min(x => x.Ch1LowInletTempMin);
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 11].Value = plcData.Max(x => x.Ch1LowInletTempMax);

            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 12].Value = plcData.Average(x => x.Ch1LowOutletTempAvg).Round();
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 13].Value = plcData.Min(x => x.Ch1LowOutletTempMin);
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 14].Value = plcData.Max(x => x.Ch1LowOutletTempMax);

            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 15].Value = plcData.Average(x => x.Ch1LowOutletPresureAvg).Round();
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 16].Value = plcData.Min(x => x.Ch1LowOutletPresureMin);
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 17].Value = plcData.Max(x => x.Ch1LowOutletPresureMax);

            if (device.DeviceType == DeviceType.DoubleHeating)
            {
               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 18].Value = plcData.Average(x => x.Ch2LowInletTempAvg).Round();
               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 19].Value = plcData.Min(x => x.Ch2LowInletTempMin);
               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 20].Value = plcData.Max(x => x.Ch2LowInletTempMax);

               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 21].Value = plcData.Average(x => x.Ch2LowOutletTempAvg).Round();
               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 22].Value = plcData.Min(x => x.Ch2LowOutletTempMin);
               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 23].Value = plcData.Max(x => x.Ch2LowOutletTempMax);

               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 24].Value = plcData.Average(x => x.Ch2LowOutletPresureAvg).Round();
               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 25].Value = plcData.Min(x => x.Ch2LowOutletPresureMin);
               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 26].Value = plcData.Max(x => x.Ch2LowOutletPresureMax);
            }

            if (device.DeviceType == DeviceType.HeatingDomestic)
            {
               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 27].Value = plcData.Average(x => x.DhwTempAvg).Round();
               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 28].Value = plcData.Min(x => x.DhwTempMin);
               sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 29].Value = plcData.Max(x => x.DhwTempMax);
            }
         }
      }
   }
}
