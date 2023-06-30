using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Plcs.Rvds.Dto
{
   public sealed class Rvd145ChartDto : PlcChartDtoBase
   {
      public float OutsideTemp { get; init; }
      public float ChHighInletPresure { get; init; }

      public float Ch1HighOutletTemp { get; init; }
      public float Ch1LowInletTemp { get; init; }
      public float Ch1LowOutletPresure { get; init; }
      public float Ch1HeatCurveTemp { get; init; }

      public float DhwTemp { get; init; }
      public float DhwTempSet { get; init; }
   }
}
