using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OfficeOpenXml;
using Phoenix.Models.Plcs.Rvds.Dto;
using Phoenix.Services.Helpers;
using Phoenix.Services.Mappings;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Enums.Devices;
using Phoenix.Shared.Extensions;


namespace Phoenix.Services.Reports.Plcs
{
   internal sealed class Rvd145PlcProcessor : IPlcProcessor
   {
      public string TemplateSheetName { get; }

      public Rvd145PlcProcessor()
      {
         TemplateSheetName = PlcHandlerHelper.PlcSheet;
      }

      public async Task FillDataAsync(UnitOfWork uow, ExcelWorksheets sheets, DateOnly date, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         Tuple<DateTime, DateTime> range = typeProcessor.GetRange(date);

         IReadOnlyDictionary<int, Rvd145ReportDto[]> plcData = await PlcHandlerHelper.GetPlcDataAsync(uow.Rvd145, range, typeProcessor, Rvd145Mappings.ToRvd145ReportDto, cancellationToken);
         foreach (KeyValuePair<int, Rvd145ReportDto[]> plc in plcData)
         {
            ExcelWorksheet? sheet = sheets.FirstOrDefault(x => x.Name == plc.Key.ToString());
            if (sheet is null)
            {
               continue;
            }

            FillData(sheet, plc.Value, typeProcessor);
         }
      }

      private static void FillData(ExcelWorksheet sheet, IReadOnlyCollection<Rvd145ReportDto> plcData, ITypeProcessor typeProcessor)
      {
         foreach (Rvd145ReportDto rvd in plcData)
         {
            int rowIndex = typeProcessor.StartingRow + typeProcessor.GetDatePart(rvd.Date);

            sheet.Cells[rowIndex, 1].Value = rvd.OutsideTempAvg.Round();
            sheet.Cells[rowIndex, 2].Value = rvd.OutsideTempMin;
            sheet.Cells[rowIndex, 3].Value = rvd.OutsideTempMax;

            sheet.Cells[rowIndex, 4].Value = rvd.ChHighInletPresureAvg.Round();
            sheet.Cells[rowIndex, 5].Value = rvd.ChHighInletPresureMin;
            sheet.Cells[rowIndex, 6].Value = rvd.ChHighInletPresureMax;

            sheet.Cells[rowIndex, 10].Value = rvd.Ch1LowInletTempAvg.Round();
            sheet.Cells[rowIndex, 11].Value = rvd.Ch1LowInletTempMin;
            sheet.Cells[rowIndex, 12].Value = rvd.Ch1LowInletTempMax;

            sheet.Cells[rowIndex, 16].Value = rvd.Ch1LowOutletPresureAvg.Round();
            sheet.Cells[rowIndex, 17].Value = rvd.Ch1LowOutletPresureMin;
            sheet.Cells[rowIndex, 18].Value = rvd.Ch1LowOutletPresureMax;

            if (rvd.DeviceType == DeviceType.HeatingDomestic)
            {
               sheet.Cells[rowIndex, 28].Value = rvd.DhwTempAvg.Round();
               sheet.Cells[rowIndex, 29].Value = rvd.DhwTempMin;
               sheet.Cells[rowIndex, 30].Value = rvd.DhwTempMax;

               sheet.Cells[rowIndex, 31].Value = rvd.DhwCirculationTempAvg.Round();
               sheet.Cells[rowIndex, 32].Value = rvd.DhwCirculationTempMin;
               sheet.Cells[rowIndex, 33].Value = rvd.DhwCirculationTempMax;
            }
         }

         sheet.Cells[sheet.Dimension.Rows, 1].Value = plcData.Average(x => x.OutsideTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 2].Value = plcData.Min(x => x.OutsideTempMin);
         sheet.Cells[sheet.Dimension.Rows, 3].Value = plcData.Max(x => x.OutsideTempMax);

         sheet.Cells[sheet.Dimension.Rows, 4].Value = plcData.Average(x => x.ChHighInletPresureAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 5].Value = plcData.Min(x => x.ChHighInletPresureMin);
         sheet.Cells[sheet.Dimension.Rows, 6].Value = plcData.Max(x => x.ChHighInletPresureMax);

         sheet.Cells[sheet.Dimension.Rows, 10].Value = plcData.Average(x => x.Ch1LowInletTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 11].Value = plcData.Min(x => x.Ch1LowInletTempMin);
         sheet.Cells[sheet.Dimension.Rows, 12].Value = plcData.Max(x => x.Ch1LowInletTempMax);

         sheet.Cells[sheet.Dimension.Rows, 16].Value = plcData.Average(x => x.Ch1LowOutletPresureAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 17].Value = plcData.Min(x => x.Ch1LowOutletPresureMin);
         sheet.Cells[sheet.Dimension.Rows, 18].Value = plcData.Max(x => x.Ch1LowOutletPresureMax);

         if (plcData.First().DeviceType == DeviceType.HeatingDomestic)
         {
            sheet.Cells[sheet.Dimension.Rows, 28].Value = plcData.Average(x => x.DhwTempAvg).Round();
            sheet.Cells[sheet.Dimension.Rows, 29].Value = plcData.Min(x => x.DhwTempMin);
            sheet.Cells[sheet.Dimension.Rows, 30].Value = plcData.Max(x => x.DhwTempMax);

            sheet.Cells[sheet.Dimension.Rows, 31].Value = plcData.Average(x => x.DhwCirculationTempAvg).Round();
            sheet.Cells[sheet.Dimension.Rows, 32].Value = plcData.Min(x => x.DhwCirculationTempMin);
            sheet.Cells[sheet.Dimension.Rows, 33].Value = plcData.Max(x => x.DhwCirculationTempMax);
         }
      }
   }
}
