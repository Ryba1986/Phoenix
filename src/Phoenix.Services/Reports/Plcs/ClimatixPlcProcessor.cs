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

      public async Task<IReadOnlyDictionary<int, ExcelAddressBase>> GetExcelDataAsync(ExcelWorksheets sheets, DateOnly date, IReadOnlyCollection<DeviceReportDto> devices, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         Dictionary<int, ExcelAddressBase> result = new();

         IReadOnlyDictionary<int, ClimatixReportDto[]> plcData = await GetPlcDataAsync<Climatix, ClimatixReportDto>(_uow.Climatix, date, typeProcessor, cancellationToken);

         foreach (DeviceReportDto device in devices)
         {
            plcData.TryGetValue(device.Id, out ClimatixReportDto[]? deviceData);
            result.Add(device.Id, GetSheetData(sheets[PlcSheet], device, deviceData, typeProcessor));
         }

         return result;
      }

      private static ExcelAddressBase GetSheetData(ExcelWorksheet sheet, DeviceReportDto device, IReadOnlyCollection<ClimatixReportDto>? plcData, ITypeProcessor typeProcessor)
      {
         sheet.Cells[typeProcessor.StartingRow - 4, 1].Value = device.Name;

         if (plcData is null)
         {
            return sheet.Dimension;
         }

         foreach (ClimatixReportDto climatix in plcData)
         {
            int rowIndex = typeProcessor.StartingRow + typeProcessor.GetDatePart(climatix.Date);

            sheet.Cells[rowIndex, 1].Value = climatix.OutsideTempAvg.Round();
            sheet.Cells[rowIndex, 2].Value = climatix.OutsideTempMin;
            sheet.Cells[rowIndex, 3].Value = climatix.OutsideTempMax;

            sheet.Cells[rowIndex, 4].Value = climatix.ChHighInletPresureAvg.Round();
            sheet.Cells[rowIndex, 5].Value = climatix.ChHighInletPresureMin;
            sheet.Cells[rowIndex, 6].Value = climatix.ChHighInletPresureMax;

            sheet.Cells[rowIndex, 7].Value = climatix.ChHighOutletPresureAvg.Round();
            sheet.Cells[rowIndex, 8].Value = climatix.ChHighOutletPresureMin;
            sheet.Cells[rowIndex, 9].Value = climatix.ChHighOutletPresureMax;

            sheet.Cells[rowIndex, 10].Value = climatix.Ch1LowInletTempAvg.Round();
            sheet.Cells[rowIndex, 11].Value = climatix.Ch1LowInletTempMin;
            sheet.Cells[rowIndex, 12].Value = climatix.Ch1LowInletTempMax;

            sheet.Cells[rowIndex, 13].Value = climatix.Ch1LowOutletTempAvg.Round();
            sheet.Cells[rowIndex, 14].Value = climatix.Ch1LowOutletTempMin;
            sheet.Cells[rowIndex, 15].Value = climatix.Ch1LowOutletTempMax;

            sheet.Cells[rowIndex, 16].Value = climatix.Ch1LowOutletPresureAvg.Round();
            sheet.Cells[rowIndex, 17].Value = climatix.Ch1LowOutletPresureMin;
            sheet.Cells[rowIndex, 18].Value = climatix.Ch1LowOutletPresureMax;

            if (device.DeviceType == DeviceType.DoubleHeating)
            {
               sheet.Cells[rowIndex, 19].Value = climatix.Ch2LowInletTempAvg.Round();
               sheet.Cells[rowIndex, 20].Value = climatix.Ch2LowInletTempMin;
               sheet.Cells[rowIndex, 21].Value = climatix.Ch2LowInletTempMax;

               sheet.Cells[rowIndex, 22].Value = climatix.Ch2LowOutletTempAvg.Round();
               sheet.Cells[rowIndex, 23].Value = climatix.Ch2LowOutletTempMin;
               sheet.Cells[rowIndex, 24].Value = climatix.Ch2LowOutletTempMax;

               sheet.Cells[rowIndex, 25].Value = climatix.Ch2LowOutletPresureAvg.Round();
               sheet.Cells[rowIndex, 26].Value = climatix.Ch2LowOutletPresureMin;
               sheet.Cells[rowIndex, 27].Value = climatix.Ch2LowOutletPresureMax;
            }

            if (device.DeviceType == DeviceType.HeatingDomestic)
            {
               sheet.Cells[rowIndex, 28].Value = climatix.DhwTempAvg.Round();
               sheet.Cells[rowIndex, 29].Value = climatix.DhwTempMin;
               sheet.Cells[rowIndex, 30].Value = climatix.DhwTempMax;
            }
         }

         sheet.Cells[sheet.Dimension.Rows, 1].Value = plcData.Average(x => x.OutsideTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 2].Value = plcData.Min(x => x.OutsideTempMin);
         sheet.Cells[sheet.Dimension.Rows, 3].Value = plcData.Max(x => x.OutsideTempMax);

         sheet.Cells[sheet.Dimension.Rows, 4].Value = plcData.Average(x => x.ChHighInletPresureAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 5].Value = plcData.Min(x => x.ChHighInletPresureMin);
         sheet.Cells[sheet.Dimension.Rows, 6].Value = plcData.Max(x => x.ChHighInletPresureMax);

         sheet.Cells[sheet.Dimension.Rows, 7].Value = plcData.Average(x => x.ChHighOutletPresureAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 8].Value = plcData.Min(x => x.ChHighOutletPresureMin);
         sheet.Cells[sheet.Dimension.Rows, 9].Value = plcData.Max(x => x.ChHighOutletPresureMax);

         sheet.Cells[sheet.Dimension.Rows, 10].Value = plcData.Average(x => x.Ch1LowInletTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 11].Value = plcData.Min(x => x.Ch1LowInletTempMin);
         sheet.Cells[sheet.Dimension.Rows, 12].Value = plcData.Max(x => x.Ch1LowInletTempMax);

         sheet.Cells[sheet.Dimension.Rows, 13].Value = plcData.Average(x => x.Ch1LowOutletTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 14].Value = plcData.Min(x => x.Ch1LowOutletTempMin);
         sheet.Cells[sheet.Dimension.Rows, 15].Value = plcData.Max(x => x.Ch1LowOutletTempMax);

         sheet.Cells[sheet.Dimension.Rows, 16].Value = plcData.Average(x => x.Ch1LowOutletPresureAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 17].Value = plcData.Min(x => x.Ch1LowOutletPresureMin);
         sheet.Cells[sheet.Dimension.Rows, 18].Value = plcData.Max(x => x.Ch1LowOutletPresureMax);

         if (device.DeviceType == DeviceType.DoubleHeating)
         {
            sheet.Cells[sheet.Dimension.Rows, 19].Value = plcData.Average(x => x.Ch2LowInletTempAvg).Round();
            sheet.Cells[sheet.Dimension.Rows, 20].Value = plcData.Min(x => x.Ch2LowInletTempMin);
            sheet.Cells[sheet.Dimension.Rows, 21].Value = plcData.Max(x => x.Ch2LowInletTempMax);

            sheet.Cells[sheet.Dimension.Rows, 22].Value = plcData.Average(x => x.Ch2LowOutletTempAvg).Round();
            sheet.Cells[sheet.Dimension.Rows, 23].Value = plcData.Min(x => x.Ch2LowOutletTempMin);
            sheet.Cells[sheet.Dimension.Rows, 24].Value = plcData.Max(x => x.Ch2LowOutletTempMax);

            sheet.Cells[sheet.Dimension.Rows, 25].Value = plcData.Average(x => x.Ch2LowOutletPresureAvg).Round();
            sheet.Cells[sheet.Dimension.Rows, 26].Value = plcData.Min(x => x.Ch2LowOutletPresureMin);
            sheet.Cells[sheet.Dimension.Rows, 27].Value = plcData.Max(x => x.Ch2LowOutletPresureMax);
         }

         if (device.DeviceType == DeviceType.HeatingDomestic)
         {
            sheet.Cells[sheet.Dimension.Rows, 28].Value = plcData.Average(x => x.DhwTempAvg).Round();
            sheet.Cells[sheet.Dimension.Rows, 29].Value = plcData.Min(x => x.DhwTempMin);
            sheet.Cells[sheet.Dimension.Rows, 30].Value = plcData.Max(x => x.DhwTempMax);
         }

         return sheet.Dimension;
      }
   }
}
