using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using OfficeOpenXml;
using Phoenix.Entities.Plcs.Rvds;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Plcs.Rvds.Dto;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Enums.Devices;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Reports.Plcs
{
   internal sealed class Rvd145PlcProcessor : PlcProcessorBase, IPlcProcessor
   {
      public Rvd145PlcProcessor(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task FillDataAsync(ExcelWorksheets sheets, DateOnly date, IReadOnlyCollection<DeviceReportDto> devices, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         IReadOnlyDictionary<int, Rvd145ReportDto[]> plcData = await GetPlcDataAsync<Rvd145, Rvd145ReportDto>(_uow.Rvd145, date, typeProcessor, cancellationToken);
         if (plcData.Count == 0)
         {
            return;
         }

         foreach (DeviceReportDto device in devices)
         {
            if (!plcData.TryGetValue(device.Id, out Rvd145ReportDto[]? deviceData))
            {
               continue;
            }

            FillSheet(sheets[device.LocationName], device, deviceData, typeProcessor);
         }
      }

      private static void FillSheet(ExcelWorksheet sheet, DeviceReportDto device, IReadOnlyCollection<Rvd145ReportDto> plcData, ITypeProcessor typeProcessor)
      {
         foreach (Rvd145ReportDto rvd in plcData)
         {
            int rowIndex = typeProcessor.StartingPoints.Row + typeProcessor.GetDatePart(rvd.Date);

            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 0].Value = rvd.OutsideTempAvg.Round();
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 1].Value = rvd.OutsideTempMin;
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 2].Value = rvd.OutsideTempMax;

            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 3].Value = rvd.ChHighInletPresureAvg.Round();
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 4].Value = rvd.ChHighInletPresureMin;
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 5].Value = rvd.ChHighInletPresureMax;

            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 9].Value = rvd.Ch1LowInletTempAvg.Round();
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 10].Value = rvd.Ch1LowInletTempMin;
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 11].Value = rvd.Ch1LowInletTempMax;

            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 15].Value = rvd.Ch1LowOutletPresureAvg.Round();
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 16].Value = rvd.Ch1LowOutletPresureMin;
            sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 17].Value = rvd.Ch1LowOutletPresureMax;

            if (device.DeviceType == DeviceType.HeatingDomestic)
            {
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 27].Value = rvd.DhwTempAvg.Round();
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 28].Value = rvd.DhwTempMin;
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 29].Value = rvd.DhwTempMax;

               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 30].Value = rvd.DhwCirculationTempAvg.Round();
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 31].Value = rvd.DhwCirculationTempMin;
               sheet.Cells[rowIndex, typeProcessor.StartingPoints.PlcColumn + 32].Value = rvd.DhwCirculationTempMax;
            }
         }

         int summaryRowIndex = typeProcessor.StartingPoints.Row + typeProcessor.SummaryRowOffset;

         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 0].Value = plcData.Average(x => x.OutsideTempAvg).Round();
         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 1].Value = plcData.Min(x => x.OutsideTempMin);
         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 2].Value = plcData.Max(x => x.OutsideTempMax);

         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 3].Value = plcData.Average(x => x.ChHighInletPresureAvg).Round();
         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 4].Value = plcData.Min(x => x.ChHighInletPresureMin);
         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 5].Value = plcData.Max(x => x.ChHighInletPresureMax);

         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 9].Value = plcData.Average(x => x.Ch1LowInletTempAvg).Round();
         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 10].Value = plcData.Min(x => x.Ch1LowInletTempMin);
         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 11].Value = plcData.Max(x => x.Ch1LowInletTempMax);

         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 15].Value = plcData.Average(x => x.Ch1LowOutletPresureAvg).Round();
         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 16].Value = plcData.Min(x => x.Ch1LowOutletPresureMin);
         sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 17].Value = plcData.Max(x => x.Ch1LowOutletPresureMax);

         if (device.DeviceType == DeviceType.HeatingDomestic)
         {
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 27].Value = plcData.Average(x => x.DhwTempAvg).Round();
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 28].Value = plcData.Min(x => x.DhwTempMin);
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 29].Value = plcData.Max(x => x.DhwTempMax);

            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 30].Value = plcData.Average(x => x.DhwCirculationTempAvg).Round();
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 31].Value = plcData.Min(x => x.DhwCirculationTempMin);
            sheet.Cells[summaryRowIndex, typeProcessor.StartingPoints.PlcColumn + 32].Value = plcData.Max(x => x.DhwCirculationTempMax);
         }
      }
   }
}
