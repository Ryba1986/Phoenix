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

      public async Task<IReadOnlyDictionary<int, ExcelAddressBase>> GetExcelDataAsync(ExcelWorksheets sheets, DateOnly date, IReadOnlyCollection<DeviceReportDto> devices, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         Dictionary<int, ExcelAddressBase> result = new();

         IReadOnlyDictionary<int, Rvd145ReportDto[]> plcData = await GetPlcDataAsync<Rvd145, Rvd145ReportDto>(_uow.Rvd145, date, typeProcessor, cancellationToken);

         foreach (DeviceReportDto device in devices)
         {
            plcData.TryGetValue(device.Id, out Rvd145ReportDto[]? deviceData);
            result.Add(device.Id, GetSheetData(sheets[PlcSheet], device, deviceData, typeProcessor));
         }

         return result;
      }

      private static ExcelAddressBase GetSheetData(ExcelWorksheet sheet, DeviceReportDto device, IReadOnlyCollection<Rvd145ReportDto>? plcData, ITypeProcessor typeProcessor)
      {
         sheet.Cells[typeProcessor.StartingRow - 4, 0].Value = device.Name;

         if (plcData is null)
         {
            return sheet.Dimension;
         }

         foreach (Rvd145ReportDto rvd in plcData)
         {
            int rowIndex = typeProcessor.StartingRow + typeProcessor.GetDatePart(rvd.Date);

            sheet.Cells[rowIndex, 0].Value = rvd.OutsideTempAvg.Round();
            sheet.Cells[rowIndex, 1].Value = rvd.OutsideTempMin;
            sheet.Cells[rowIndex, 2].Value = rvd.OutsideTempMax;

            sheet.Cells[rowIndex, 3].Value = rvd.ChHighInletPresureAvg.Round();
            sheet.Cells[rowIndex, 4].Value = rvd.ChHighInletPresureMin;
            sheet.Cells[rowIndex, 5].Value = rvd.ChHighInletPresureMax;

            sheet.Cells[rowIndex, 9].Value = rvd.Ch1LowInletTempAvg.Round();
            sheet.Cells[rowIndex, 10].Value = rvd.Ch1LowInletTempMin;
            sheet.Cells[rowIndex, 11].Value = rvd.Ch1LowInletTempMax;

            sheet.Cells[rowIndex, 15].Value = rvd.Ch1LowOutletPresureAvg.Round();
            sheet.Cells[rowIndex, 16].Value = rvd.Ch1LowOutletPresureMin;
            sheet.Cells[rowIndex, 17].Value = rvd.Ch1LowOutletPresureMax;

            if (device.DeviceType == DeviceType.HeatingDomestic)
            {
               sheet.Cells[rowIndex, 27].Value = rvd.DhwTempAvg.Round();
               sheet.Cells[rowIndex, 28].Value = rvd.DhwTempMin;
               sheet.Cells[rowIndex, 29].Value = rvd.DhwTempMax;

               sheet.Cells[rowIndex, 30].Value = rvd.DhwCirculationTempAvg.Round();
               sheet.Cells[rowIndex, 31].Value = rvd.DhwCirculationTempMin;
               sheet.Cells[rowIndex, 32].Value = rvd.DhwCirculationTempMax;
            }
         }

         sheet.Cells[sheet.Dimension.Rows, 0].Value = plcData.Average(x => x.OutsideTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 1].Value = plcData.Min(x => x.OutsideTempMin);
         sheet.Cells[sheet.Dimension.Rows, 2].Value = plcData.Max(x => x.OutsideTempMax);

         sheet.Cells[sheet.Dimension.Rows, 3].Value = plcData.Average(x => x.ChHighInletPresureAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 4].Value = plcData.Min(x => x.ChHighInletPresureMin);
         sheet.Cells[sheet.Dimension.Rows, 5].Value = plcData.Max(x => x.ChHighInletPresureMax);

         sheet.Cells[sheet.Dimension.Rows, 9].Value = plcData.Average(x => x.Ch1LowInletTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 10].Value = plcData.Min(x => x.Ch1LowInletTempMin);
         sheet.Cells[sheet.Dimension.Rows, 11].Value = plcData.Max(x => x.Ch1LowInletTempMax);

         sheet.Cells[sheet.Dimension.Rows, 15].Value = plcData.Average(x => x.Ch1LowOutletPresureAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 16].Value = plcData.Min(x => x.Ch1LowOutletPresureMin);
         sheet.Cells[sheet.Dimension.Rows, 17].Value = plcData.Max(x => x.Ch1LowOutletPresureMax);

         if (device.DeviceType == DeviceType.HeatingDomestic)
         {
            sheet.Cells[sheet.Dimension.Rows, 27].Value = plcData.Average(x => x.DhwTempAvg).Round();
            sheet.Cells[sheet.Dimension.Rows, 28].Value = plcData.Min(x => x.DhwTempMin);
            sheet.Cells[sheet.Dimension.Rows, 29].Value = plcData.Max(x => x.DhwTempMax);

            sheet.Cells[sheet.Dimension.Rows, 30].Value = plcData.Average(x => x.DhwCirculationTempAvg).Round();
            sheet.Cells[sheet.Dimension.Rows, 31].Value = plcData.Min(x => x.DhwCirculationTempMin);
            sheet.Cells[sheet.Dimension.Rows, 32].Value = plcData.Max(x => x.DhwCirculationTempMax);
         }

         return sheet.Dimension;
      }
   }
}
