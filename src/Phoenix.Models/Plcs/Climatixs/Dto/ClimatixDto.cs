using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Plcs.Climatixs.Dto
{
   public sealed class ClimatixDto : PlcDtoBase
   {
      public float OutsideTemp { get; init; }
      public float ChHighInletPresure { get; init; }
      public float ChHighOutletPresure { get; init; }
      public bool Alarm { get; init; }

      public float Ch1LowInletTemp { get; init; }
      public float Ch1LowOutletTemp { get; init; }
      public float Ch1LowOutletPresure { get; init; }
      public float Ch1HeatCurveTemp { get; init; }
      public bool Ch1PumpAlarm { get; init; }
      public bool Ch1PumpStatus { get; init; }
      public byte Ch1ValvePosition { get; init; }
      public bool Ch1Status { get; init; }

      public float Ch2LowInletTemp { get; init; }
      public float Ch2LowOutletTemp { get; init; }
      public float Ch2LowOutletPresure { get; init; }
      public float Ch2HeatCurveTemp { get; init; }
      public bool Ch2PumpAlarm { get; init; }
      public bool Ch2PumpStatus { get; init; }
      public byte Ch2ValvePosition { get; init; }
      public bool Ch2Status { get; init; }

      public float DhwTemp { get; init; }
      public float DhwTempSet { get; init; }
      public bool DhwPumpAlarm { get; init; }
      public bool DhwPumpStatus { get; init; }
      public byte DhwValvePosition { get; init; }
      public bool DhwStatus { get; init; }
   }
}
