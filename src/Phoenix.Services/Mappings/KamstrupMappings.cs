using System;
using System.Linq;
using System.Linq.Expressions;
using Phoenix.Entities.Plcs.Meters;
using Phoenix.Models.Plcs;
using Phoenix.Models.Plcs.Meters.Dto;

namespace Phoenix.Services.Mappings
{
   internal static class KamstrupMappings
   {
      public static KamstrupDto ToKamstrupDto(this Kamstrup kamstrup)
      {
         return new()
         {
            Date = kamstrup.Date,
            DeviceName = kamstrup.Device.Name,

            InletTemp = kamstrup.InletTemp,
            OutletTemp = kamstrup.OutletTemp,
            Power = kamstrup.Power,
            Volume = kamstrup.Volume,
            VolumeSummary = kamstrup.VolumeSummary,
            EnergySummary = kamstrup.EnergySummary,
            HourCount = kamstrup.HourCount,
            ErrorCode = kamstrup.ErrorCode,
         };
      }

      public static KamstrupChartDto ToKamstrupChartDto(this Kamstrup kamstrup)
      {
         return new()
         {
            Date = kamstrup.Date,

            InletTemp = kamstrup.InletTemp,
            OutletTemp = kamstrup.OutletTemp,
            Power = kamstrup.Power,
            Volume = kamstrup.Volume,
         };
      }

      public static Expression<Func<IGrouping<PlcGroupBy, Kamstrup>, KamstrupReportDto>> ToKamstrupReportDto = group => new()
      {
         DeviceId = group.Key.DeviceId,
         Date = group.Min(x => x.Date),

         InletTempAvg = group.Average(x => x.InletTemp),
         InletTempMin = group.Min(x => x.InletTemp),
         InletTempMax = group.Max(x => x.InletTemp),

         OutletTempAvg = group.Average(x => x.OutletTemp),
         OutletTempMin = group.Min(x => x.OutletTemp),
         OutletTempMax = group.Max(x => x.OutletTemp),

         PowerAvg = group.Average(x => x.Power),
         PowerMin = group.Min(x => x.Power),
         PowerMax = group.Max(x => x.Power),

         VolumeAvg = group.Average(x => x.Volume),
         VolumeMin = group.Min(x => x.Volume),
         VolumeMax = group.Max(x => x.Volume),

         VolumeSummaryMax = group.Max(x => x.VolumeSummary),
         EnergySummaryMax = group.Max(x => x.EnergySummary),
      };
   }
}
