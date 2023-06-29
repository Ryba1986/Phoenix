using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Plcs.Climatixs.Dto
{
   public sealed class ClimatixChartDto : PlcChartDtoBase
   {
      public float OutsideTemp { get; init; }
      public float ChHighInletPresure { get; init; }
      public float ChHighOutletPresure { get; init; }

      public float Ch1LowInletTemp { get; init; }
      public float Ch1LowOutletTemp { get; init; }
      public float Ch1LowOutletPresure { get; init; }
      public float Ch1HeatCurveTemp { get; init; }

      public float Ch2LowInletTemp { get; init; }
      public float Ch2LowOutletTemp { get; init; }
      public float Ch2LowOutletPresure { get; init; }
      public float Ch2HeatCurveTemp { get; init; }

      public float DhwTemp { get; init; }
      public float DhwTempSet { get; init; }
   }
}
