using System;
using System.Linq;
using System.Linq.Expressions;
using Phoenix.Entities.Plcs.Climatixs;
using Phoenix.Models.Plcs;
using Phoenix.Models.Plcs.Climatixs.Dto;

namespace Phoenix.Services.Mappings
{
   internal static class ClimatixMappings
   {
      public static ClimatixDto ToClimatixDto(this Climatix climatix)
      {
         return new()
         {
            Date = climatix.Date,
            DeviceType = climatix.Device.DeviceType,
            DeviceName = climatix.Device.Name,

            OutsideTemp = climatix.OutsideTemp,
            ChHighInletPresure = climatix.ChHighInletPresure,
            ChHighOutletPresure = climatix.ChHighOutletPresure,
            Alarm = climatix.Alarm,

            Ch1LowInletTemp = climatix.Ch1LowInletTemp,
            Ch1LowOutletTemp = climatix.Ch1LowOutletTemp,
            Ch1LowOutletPresure = climatix.Ch1LowOutletPresure,
            Ch1HeatCurveTemp = climatix.Ch1HeatCurveTemp,
            Ch1PumpAlarm = climatix.Ch1PumpAlarm,
            Ch1PumpStatus = climatix.Ch1PumpStatus,
            Ch1ValvePosition = climatix.Ch1ValvePosition,
            Ch1Status = climatix.Ch1Status,

            Ch2LowInletTemp = climatix.Ch2LowInletTemp,
            Ch2LowOutletTemp = climatix.Ch2LowOutletTemp,
            Ch2LowOutletPresure = climatix.Ch2LowOutletPresure,
            Ch2HeatCurveTemp = climatix.Ch2HeatCurveTemp,
            Ch2PumpAlarm = climatix.Ch2PumpAlarm,
            Ch2PumpStatus = climatix.Ch2PumpStatus,
            Ch2ValvePosition = climatix.Ch2ValvePosition,
            Ch2Status = climatix.Ch2Status,

            DhwTemp = climatix.DhwTemp,
            DhwTempSet = climatix.DhwTempSet,
            DhwPumpAlarm = climatix.DhwPumpAlarm,
            DhwPumpStatus = climatix.DhwPumpStatus,
            DhwValvePosition = climatix.DhwValvePosition,
            DhwStatus = climatix.DhwStatus,
         };
      }

      public static ClimatixChartDto ToClimatixChartDto(this Climatix climatix)
      {
         return new()
         {
            Date = climatix.Date,

            OutsideTemp = climatix.OutsideTemp,
            ChHighInletPresure = climatix.ChHighInletPresure,
            ChHighOutletPresure = climatix.ChHighOutletPresure,

            Ch1LowInletTemp = climatix.Ch1LowInletTemp,
            Ch1LowOutletTemp = climatix.Ch1LowOutletTemp,
            Ch1LowOutletPresure = climatix.Ch1LowOutletPresure,
            Ch1HeatCurveTemp = climatix.Ch1HeatCurveTemp,

            Ch2LowInletTemp = climatix.Ch2LowInletTemp,
            Ch2LowOutletTemp = climatix.Ch2LowOutletTemp,
            Ch2LowOutletPresure = climatix.Ch2LowOutletPresure,
            Ch2HeatCurveTemp = climatix.Ch2HeatCurveTemp,

            DhwTemp = climatix.DhwTemp,
            DhwTempSet = climatix.DhwTempSet,
         };
      }

      public static Expression<Func<IGrouping<PlcGroupBy, Climatix>, ClimatixReportDto>> ToClimatixReportDto = group => new()
      {
         DeviceId = group.Key.DeviceId,
         DeviceType = group.Key.DeviceType,
         Date = group.Min(x => x.Date),

         OutsideTempAvg = group.Average(x => x.OutsideTemp),
         OutsideTempMin = group.Min(x => x.OutsideTemp),
         OutsideTempMax = group.Max(x => x.OutsideTemp),

         ChHighInletPresureAvg = group.Average(x => x.ChHighInletPresure),
         ChHighInletPresureMin = group.Min(x => x.ChHighInletPresure),
         ChHighInletPresureMax = group.Max(x => x.ChHighInletPresure),

         ChHighOutletPresureAvg = group.Average(x => x.ChHighOutletPresure),
         ChHighOutletPresureMin = group.Min(x => x.ChHighOutletPresure),
         ChHighOutletPresureMax = group.Max(x => x.ChHighOutletPresure),

         Ch1LowInletTempAvg = group.Average(x => x.Ch1LowInletTemp),
         Ch1LowInletTempMin = group.Min(x => x.Ch1LowInletTemp),
         Ch1LowInletTempMax = group.Max(x => x.Ch1LowInletTemp),

         Ch1LowOutletTempAvg = group.Average(x => x.Ch1LowOutletTemp),
         Ch1LowOutletTempMin = group.Min(x => x.Ch1LowOutletTemp),
         Ch1LowOutletTempMax = group.Max(x => x.Ch1LowOutletTemp),

         Ch1LowOutletPresureAvg = group.Average(x => x.Ch1LowOutletPresure),
         Ch1LowOutletPresureMin = group.Min(x => x.Ch1LowOutletPresure),
         Ch1LowOutletPresureMax = group.Max(x => x.Ch1LowOutletPresure),

         Ch2LowInletTempAvg = group.Average(x => x.Ch2LowInletTemp),
         Ch2LowInletTempMin = group.Min(x => x.Ch2LowInletTemp),
         Ch2LowInletTempMax = group.Max(x => x.Ch2LowInletTemp),

         Ch2LowOutletTempAvg = group.Average(x => x.Ch2LowOutletTemp),
         Ch2LowOutletTempMin = group.Min(x => x.Ch2LowOutletTemp),
         Ch2LowOutletTempMax = group.Max(x => x.Ch2LowOutletTemp),

         Ch2LowOutletPresureAvg = group.Average(x => x.Ch2LowOutletPresure),
         Ch2LowOutletPresureMin = group.Min(x => x.Ch2LowOutletPresure),
         Ch2LowOutletPresureMax = group.Max(x => x.Ch2LowOutletPresure),

         DhwTempAvg = group.Average(x => x.DhwTemp),
         DhwTempMin = group.Min(x => x.DhwTemp),
         DhwTempMax = group.Max(x => x.DhwTemp),
      };
   }
}
