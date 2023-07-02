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

      public async Task FillDataAsync(ExcelWorksheets sheets, DateOnly date, IReadOnlyCollection<DeviceReportDto> devices, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         IReadOnlyDictionary<int, KamstrupReportDto[]> plcData = await GetPlcDataAsync<Kamstrup, KamstrupReportDto>(_uow.Kamstrup, date, typeProcessor, cancellationToken);
         if (plcData.Count == 0)
         {
            return;
         }

         IReadOnlyDictionary<int, KamstrupDto> beforeData = await GetBeforeDataAsync(_uow.Kamstrup, date, devices, typeProcessor, cancellationToken);
         if (beforeData.Count == 0)
         {
            return;
         }

         foreach (var group in devices.GroupBy(x => x.LocationName))
         {
            ushort startColumn = typeProcessor.StartingPoints.MeterColumn;

            foreach (DeviceReportDto device in group)
            {
               if (!plcData.TryGetValue(device.Id, out KamstrupReportDto[]? currentData) || !beforeData.TryGetValue(device.Id, out KamstrupDto? beforePlc))
               {
                  continue;
               }

               FillSheet(sheets[device.LocationName], device, currentData, beforePlc, typeProcessor, ref startColumn);
            }
         }
      }

      private static void FillSheet(ExcelWorksheet sheet, DeviceReportDto device, IReadOnlyCollection<KamstrupReportDto> currentData, KamstrupDto beforeMeter, ITypeProcessor typeProcessor, ref ushort startColumn)
      {
         float beforeVolumeSummary = beforeMeter.VolumeSummary;
         float beforeEnergySummary = beforeMeter.EnergySummary;

         foreach (KamstrupReportDto meter in currentData)
         {
            int rowIndex = typeProcessor.StartingPoints.Row + typeProcessor.GetDatePart(meter.Date);

            sheet.Cells[rowIndex, startColumn + 0].Value = meter.InletTempAvg.Round();
            sheet.Cells[rowIndex, startColumn + 1].Value = meter.InletTempMin;
            sheet.Cells[rowIndex, startColumn + 2].Value = meter.InletTempMax;

            sheet.Cells[rowIndex, startColumn + 3].Value = meter.OutletTempAvg.Round();
            sheet.Cells[rowIndex, startColumn + 4].Value = meter.OutletTempMin;
            sheet.Cells[rowIndex, startColumn + 5].Value = meter.OutletTempMax;

            sheet.Cells[rowIndex, startColumn + 6].Value = meter.PowerAvg.Round();
            sheet.Cells[rowIndex, startColumn + 7].Value = meter.PowerMin;
            sheet.Cells[rowIndex, startColumn + 8].Value = meter.PowerMax;

            sheet.Cells[rowIndex, startColumn + 9].Value = meter.VolumeAvg.Round();
            sheet.Cells[rowIndex, startColumn + 10].Value = meter.VolumeMin;
            sheet.Cells[rowIndex, startColumn + 11].Value = meter.VolumeMax;

            sheet.Cells[rowIndex, startColumn + 12].Value = meter.VolumeSummaryMax - beforeVolumeSummary;
            beforeVolumeSummary = meter.VolumeSummaryMax;

            sheet.Cells[rowIndex, startColumn + 13].Value = meter.EnergySummaryMax - beforeEnergySummary;
            beforeEnergySummary = meter.EnergySummaryMax;
         }

         int summaryRowIndex = typeProcessor.StartingPoints.Row + typeProcessor.SummaryRowOffset;

         sheet.Cells[typeProcessor.StartingPoints.Row - 4, startColumn].Value = device.Name;

         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Average(x => x.InletTempAvg).Round();
         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Min(x => x.InletTempMin);
         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Max(x => x.InletTempMax);

         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Average(x => x.OutletTempAvg).Round();
         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Min(x => x.OutletTempMin);
         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Max(x => x.OutletTempMax);

         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Average(x => x.PowerAvg).Round();
         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Min(x => x.PowerMin);
         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Max(x => x.PowerMax);

         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Average(x => x.VolumeAvg).Round();
         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Min(x => x.VolumeMin);
         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Max(x => x.VolumeMax);

         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Max(x => x.VolumeSummaryMax) - beforeMeter.VolumeSummary;
         sheet.Cells[summaryRowIndex, startColumn++].Value = currentData.Max(x => x.EnergySummaryMax) - beforeMeter.EnergySummary;
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
