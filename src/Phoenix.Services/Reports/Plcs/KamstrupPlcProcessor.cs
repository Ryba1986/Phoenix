using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Phoenix.Entities.Plcs.Meters;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Plcs.Meters.Dto;
using Phoenix.Models.Utilities;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Reports.Plcs
{
   internal sealed class KamstrupPlcProcessor : PlcProcessorBase, IPlcProcessor
   {
      public KamstrupPlcProcessor(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyDictionary<int, ExcelAddressBase>> GetExcelDataAsync(ExcelWorksheets sheets, DateOnly date, IReadOnlyCollection<DeviceReportDto> devices, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         Dictionary<int, ExcelAddressBase> result = new();

         IReadOnlyDictionary<int, KamstrupReportDto[]> plcData = await GetPlcDataAsync<Kamstrup, KamstrupReportDto>(_uow.Kamstrup, date, typeProcessor, cancellationToken);
         if (plcData.Count == 0)
         {
            return result;
         }

         IReadOnlyDictionary<int, KamstrupDto> beforeData = await GetBeforeDataAsync(_uow.Kamstrup, date, devices, typeProcessor, cancellationToken);
         if (beforeData.Count == 0)
         {
            return result;
         }

         foreach (DeviceReportDto device in devices)
         {
            if (!plcData.TryGetValue(device.Id, out KamstrupReportDto[]? currentData) || !beforeData.TryGetValue(device.Id, out KamstrupDto? beforePlc))
            {
               continue;
            }

            result.Add(device.Id, GetSheetData(sheets[MeterSheet], device, currentData, beforePlc, typeProcessor));
         }

         return result;
      }

      private static ExcelAddressBase GetSheetData(ExcelWorksheet sheet, DeviceReportDto device, IReadOnlyCollection<KamstrupReportDto> currentData, KamstrupDto beforeMeter, ITypeProcessor typeProcessor)
      {
         float beforeVolumeSummary = beforeMeter.VolumeSummary;
         float beforeEnergySummary = beforeMeter.EnergySummary;

         foreach (KamstrupReportDto meter in currentData)
         {
            int rowIndex = typeProcessor.StartingRow + typeProcessor.GetDatePart(meter.Date);

            sheet.Cells[rowIndex, 0].Value = meter.InletTempAvg.Round();
            sheet.Cells[rowIndex, 1].Value = meter.InletTempMin;
            sheet.Cells[rowIndex, 2].Value = meter.InletTempMax;

            sheet.Cells[rowIndex, 3].Value = meter.OutletTempAvg.Round();
            sheet.Cells[rowIndex, 4].Value = meter.OutletTempMin;
            sheet.Cells[rowIndex, 5].Value = meter.OutletTempMax;

            sheet.Cells[rowIndex, 6].Value = meter.PowerAvg.Round();
            sheet.Cells[rowIndex, 7].Value = meter.PowerMin;
            sheet.Cells[rowIndex, 8].Value = meter.PowerMax;

            sheet.Cells[rowIndex, 9].Value = meter.VolumeAvg.Round();
            sheet.Cells[rowIndex, 10].Value = meter.VolumeMin;
            sheet.Cells[rowIndex, 11].Value = meter.VolumeMax;

            sheet.Cells[rowIndex, 12].Value = meter.VolumeSummaryMax - beforeVolumeSummary;
            beforeVolumeSummary = meter.VolumeSummaryMax;

            sheet.Cells[rowIndex, 13].Value = meter.EnergySummaryMax - beforeEnergySummary;
            beforeEnergySummary = meter.EnergySummaryMax;
         }

         sheet.Cells[typeProcessor.StartingRow - 4, 0].Value = device.Name;

         sheet.Cells[sheet.Dimension.Rows, 0].Value = currentData.Average(x => x.InletTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 1].Value = currentData.Min(x => x.InletTempMin);
         sheet.Cells[sheet.Dimension.Rows, 2].Value = currentData.Max(x => x.InletTempMax);

         sheet.Cells[sheet.Dimension.Rows, 3].Value = currentData.Average(x => x.OutletTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 4].Value = currentData.Min(x => x.OutletTempMin);
         sheet.Cells[sheet.Dimension.Rows, 5].Value = currentData.Max(x => x.OutletTempMax);

         sheet.Cells[sheet.Dimension.Rows, 6].Value = currentData.Average(x => x.PowerAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 7].Value = currentData.Min(x => x.PowerMin);
         sheet.Cells[sheet.Dimension.Rows, 8].Value = currentData.Max(x => x.PowerMax);

         sheet.Cells[sheet.Dimension.Rows, 9].Value = currentData.Average(x => x.VolumeAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 10].Value = currentData.Min(x => x.VolumeMin);
         sheet.Cells[sheet.Dimension.Rows, 11].Value = currentData.Max(x => x.VolumeMax);

         sheet.Cells[sheet.Dimension.Rows, 12].Value = currentData.Max(x => x.VolumeSummaryMax) - beforeMeter.VolumeSummary;
         sheet.Cells[sheet.Dimension.Rows, 13].Value = currentData.Max(x => x.EnergySummaryMax) - beforeMeter.EnergySummary;

         return sheet.Dimension;
      }

      private async Task<IReadOnlyDictionary<int, KamstrupDto>> GetBeforeDataAsync(DbSet<Kamstrup> plc, DateOnly date, IReadOnlyCollection<DeviceReportDto> devices, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         DateRange range = typeProcessor.GetRange(date);
         Dictionary<int, KamstrupDto> result = new();

         foreach (DeviceReportDto device in devices)
         {
            KamstrupDto? before = await plc
               .AsNoTracking()
               .Where(x =>
                  x.Date < range.Start &&
                  x.DeviceId == device.Id
               )
               .OrderByDescending(x => x.Date)
               .ProjectTo<KamstrupDto>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(cancellationToken);

            if (before is not null)
            {
               result.Add(device.Id, before);
               continue;
            }

            before = await plc
               .AsNoTracking()
               .Where(x =>
                  x.Date < range.End &&
                  x.DeviceId == device.Id
               )
               .OrderBy(x => x.Date)
               .ProjectTo<KamstrupDto>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(cancellationToken);

            if (before is not null)
            {
               result.Add(device.Id, before);
            }
         }

         return result;
      }
   }
}
