using System;
using System.Linq;
using System.Linq.Expressions;
using Phoenix.Entities.Plcs.Rvds;
using Phoenix.Models.Plcs;
using Phoenix.Models.Plcs.Rvds.Dto;

namespace Phoenix.Services.Mappings
{
   internal static class Rvd145Mappings
   {
      public static Rvd145Dto ToRvd145Dto(this Rvd145 rvd)
      {
         return new()
         {
            Date = rvd.Date,
            DeviceType = rvd.Device.DeviceType,
            DeviceName = rvd.Device.Name,

            OutsideTemp = rvd.OutsideTemp,
            ChHighInletPresure = rvd.ChHighInletPresure,
            Alarm = rvd.Alarm,

            Ch1HighOutletTemp = rvd.Ch1HighOutletTemp,
            Ch1LowInletTemp = rvd.Ch1LowInletTemp,
            Ch1LowOutletPresure = rvd.Ch1LowOutletPresure,
            Ch1HeatCurveTemp = rvd.Ch1HeatCurveTemp,
            Ch1PumpStatus = rvd.Ch1PumpStatus,
            Ch1Status = rvd.Ch1Status,

            DhwTemp = rvd.DhwTemp,
            DhwTempSet = rvd.DhwTempSet,
            DhwCirculationTemp = rvd.DhwCirculationTemp,
            DhwPumpStatus = rvd.DhwPumpStatus,
            DhwStatus = rvd.DhwStatus,
         };
      }

      public static Rvd145ChartDto ToRvd145ChartDto(this Rvd145 rvd)
      {
         return new()
         {
            Date = rvd.Date,

            OutsideTemp = rvd.OutsideTemp,
            ChHighInletPresure = rvd.ChHighInletPresure,

            Ch1HighOutletTemp = rvd.Ch1HighOutletTemp,
            Ch1LowInletTemp = rvd.Ch1LowInletTemp,
            Ch1LowOutletPresure = rvd.Ch1LowOutletPresure,
            Ch1HeatCurveTemp = rvd.Ch1HeatCurveTemp,

            DhwTemp = rvd.DhwTemp,
            DhwTempSet = rvd.DhwTempSet,
         };
      }

      public static Expression<Func<IGrouping<PlcGroupBy, Rvd145>, Rvd145ReportDto>> ToRvd145ReportDto = group => new()
      {
         DeviceId = group.Key.DeviceId,
         Date = group.Min(x => x.Date),

         OutsideTempAvg = group.Average(x => x.OutsideTemp),
         OutsideTempMin = group.Min(x => x.OutsideTemp),
         OutsideTempMax = group.Max(x => x.OutsideTemp),

         ChHighInletPresureAvg = group.Average(x => x.ChHighInletPresure),
         ChHighInletPresureMin = group.Min(x => x.ChHighInletPresure),
         ChHighInletPresureMax = group.Max(x => x.ChHighInletPresure),

         Ch1Status = group.Any(x => x.Ch1Status),

         Ch1LowInletTempAvg = group.Average(x => x.Ch1LowInletTemp),
         Ch1LowInletTempMin = group.Min(x => x.Ch1LowInletTemp),
         Ch1LowInletTempMax = group.Max(x => x.Ch1LowInletTemp),

         Ch1LowOutletPresureAvg = group.Average(x => x.Ch1LowOutletPresure),
         Ch1LowOutletPresureMin = group.Min(x => x.Ch1LowOutletPresure),
         Ch1LowOutletPresureMax = group.Max(x => x.Ch1LowOutletPresure),

         DhwStatus = group.Any(x => x.DhwStatus),

         DhwTempAvg = group.Average(x => x.DhwTemp),
         DhwTempMin = group.Min(x => x.DhwTemp),
         DhwTempMax = group.Max(x => x.DhwTemp),

         DhwCirculationTempAvg = group.Average(x => x.DhwCirculationTemp),
         DhwCirculationTempMin = group.Min(x => x.DhwCirculationTemp),
         DhwCirculationTempMax = group.Max(x => x.DhwCirculationTemp),
      };
   }
}
