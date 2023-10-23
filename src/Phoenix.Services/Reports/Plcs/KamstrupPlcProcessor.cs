using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Phoenix.Models.Plcs.Meters.Dto;
using Phoenix.Services.Helpers;
using Phoenix.Services.Mappings;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Reports.Plcs
{
   internal sealed class KamstrupPlcProcessor : IPlcProcessor
   {
      public string TemplateSheetName { get; }

      public KamstrupPlcProcessor()
      {
         TemplateSheetName = PlcHandlerHelper.MeterSheet;
      }

      public async Task FillDataAsync(UnitOfWork uow, ExcelWorksheets sheets, DateOnly date, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         Tuple<DateTime, DateTime> range = typeProcessor.GetRange(date);

         IReadOnlyDictionary<int, KamstrupReportDto[]> plcData = await PlcHandlerHelper.GetPlcDataAsync(uow.Kamstrup, range, typeProcessor, KamstrupMappings.ToKamstrupReportDto, cancellationToken);
         foreach (KeyValuePair<int, KamstrupReportDto[]> plc in plcData)
         {
            KamstrupDto before = await GetBeforeDataAsync(uow, plc.Key, range.Item1, cancellationToken);
            FillData(sheets[plc.Key.ToString()], before, plc.Value, typeProcessor);
         }
      }

      private static void FillData(ExcelWorksheet sheet, KamstrupDto before, IReadOnlyCollection<KamstrupReportDto> plcData, ITypeProcessor typeProcessor)
      {
         float beforeVolumeSummary = before.VolumeSummary;
         float beforeEnergySummary = before.EnergySummary;

         foreach (KamstrupReportDto kamstrup in plcData)
         {
            int rowIndex = typeProcessor.StartingRow + typeProcessor.GetDatePart(kamstrup.Date);

            sheet.Cells[rowIndex, 1].Value = kamstrup.InletTempAvg.Round();
            sheet.Cells[rowIndex, 2].Value = kamstrup.InletTempMin;
            sheet.Cells[rowIndex, 3].Value = kamstrup.InletTempMax;

            sheet.Cells[rowIndex, 4].Value = kamstrup.OutletTempAvg.Round();
            sheet.Cells[rowIndex, 5].Value = kamstrup.OutletTempMin;
            sheet.Cells[rowIndex, 6].Value = kamstrup.OutletTempMax;

            sheet.Cells[rowIndex, 7].Value = kamstrup.PowerAvg.Round();
            sheet.Cells[rowIndex, 8].Value = kamstrup.PowerMin;
            sheet.Cells[rowIndex, 9].Value = kamstrup.PowerMax;

            sheet.Cells[rowIndex, 10].Value = kamstrup.VolumeAvg.Round();
            sheet.Cells[rowIndex, 11].Value = kamstrup.VolumeMin;
            sheet.Cells[rowIndex, 12].Value = kamstrup.VolumeMax;

            sheet.Cells[rowIndex, 13].Value = kamstrup.VolumeSummaryMax - beforeVolumeSummary;
            beforeVolumeSummary = kamstrup.VolumeSummaryMax;

            sheet.Cells[rowIndex, 14].Value = kamstrup.EnergySummaryMax - beforeEnergySummary;
            beforeEnergySummary = kamstrup.EnergySummaryMax;
         }

         sheet.Cells[sheet.Dimension.Rows, 1].Value = plcData.Average(x => x.InletTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 2].Value = plcData.Min(x => x.InletTempMin);
         sheet.Cells[sheet.Dimension.Rows, 3].Value = plcData.Max(x => x.InletTempMax);

         sheet.Cells[sheet.Dimension.Rows, 4].Value = plcData.Average(x => x.OutletTempAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 5].Value = plcData.Min(x => x.OutletTempMin);
         sheet.Cells[sheet.Dimension.Rows, 6].Value = plcData.Max(x => x.OutletTempMax);

         sheet.Cells[sheet.Dimension.Rows, 7].Value = plcData.Average(x => x.PowerAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 8].Value = plcData.Min(x => x.PowerMin);
         sheet.Cells[sheet.Dimension.Rows, 9].Value = plcData.Max(x => x.PowerMax);

         sheet.Cells[sheet.Dimension.Rows, 10].Value = plcData.Average(x => x.VolumeAvg).Round();
         sheet.Cells[sheet.Dimension.Rows, 11].Value = plcData.Min(x => x.VolumeMin);
         sheet.Cells[sheet.Dimension.Rows, 12].Value = plcData.Max(x => x.VolumeMax);

         sheet.Cells[sheet.Dimension.Rows, 13].Value = plcData.Max(x => x.VolumeSummaryMax) - before.VolumeSummary;
         sheet.Cells[sheet.Dimension.Rows, 14].Value = plcData.Max(x => x.EnergySummaryMax) - before.EnergySummary;
      }

      private async Task<KamstrupDto> GetBeforeDataAsync(UnitOfWork uow, int deviceId, DateTime date, CancellationToken cancellationToken)
      {
         KamstrupDto? before = await uow.Kamstrup
            .AsNoTracking()
            .Include(x => x.Device)
            .Where(x =>
               x.Date < date &&
               x.DeviceId == deviceId
            )
            .OrderByDescending(x => x.Date)
            .Select(x => x.ToKamstrupDto())
            .FirstOrDefaultAsync(cancellationToken);

         if (before is not null)
         {
            return before;
         }

         return await uow.Kamstrup
            .AsNoTracking()
            .Include(x => x.Device)
            .Where(x =>
               x.Date >= date &&
               x.DeviceId == deviceId
            )
            .OrderBy(x => x.Date)
            .Select(x => x.ToKamstrupDto())
            .FirstAsync(cancellationToken);
      }
   }
}
