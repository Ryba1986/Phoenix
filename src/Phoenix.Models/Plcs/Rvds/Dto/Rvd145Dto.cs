using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Plcs.Rvds.Dto
{
   public sealed class Rvd145Dto : PlcDtoBase
   {
      public float OutsideTemp { get; init; }
      public float ChHighInletPresure { get; init; }
      public short Alarm { get; init; }

      public float Ch1HighOutletTemp { get; init; }
      public float Ch1LowInletTemp { get; init; }
      public float Ch1LowOutletPresure { get; init; }
      public float Ch1HeatCurveTemp { get; init; }
      public bool Ch1PumpStatus { get; init; }
      public bool Ch1Status { get; init; }

      public float DhwTemp { get; init; }
      public float DhwTempSet { get; init; }
      public float DhwCirculationTemp { get; init; }
      public bool DhwPumpStatus { get; init; }
      public bool DhwStatus { get; init; }
   }
}
