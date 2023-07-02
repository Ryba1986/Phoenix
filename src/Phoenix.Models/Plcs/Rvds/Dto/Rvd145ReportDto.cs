using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Plcs.Rvds.Dto
{
   public sealed class Rvd145ReportDto : PlcReportDtoBase
   {
      public float OutsideTempAvg { get; init; }
      public float OutsideTempMin { get; init; }
      public float OutsideTempMax { get; init; }

      public float ChHighInletPresureAvg { get; init; }
      public float ChHighInletPresureMin { get; init; }
      public float ChHighInletPresureMax { get; init; }

      public float Ch1LowInletTempAvg { get; init; }
      public float Ch1LowInletTempMin { get; init; }
      public float Ch1LowInletTempMax { get; init; }

      public float Ch1LowOutletPresureAvg { get; init; }
      public float Ch1LowOutletPresureMin { get; init; }
      public float Ch1LowOutletPresureMax { get; init; }

      public float DhwTempAvg { get; init; }
      public float DhwTempMin { get; init; }
      public float DhwTempMax { get; init; }

      public float DhwCirculationTempAvg { get; init; }
      public float DhwCirculationTempMin { get; init; }
      public float DhwCirculationTempMax { get; init; }
   }
}
