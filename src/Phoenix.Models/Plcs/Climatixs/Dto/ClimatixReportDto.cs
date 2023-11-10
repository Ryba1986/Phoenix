using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Plcs.Climatixs.Dto
{
   public sealed class ClimatixReportDto : PlcReportDtoBase
   {
      public float OutsideTempAvg { get; init; }
      public float OutsideTempMin { get; init; }
      public float OutsideTempMax { get; init; }

      public float ChHighInletPresureAvg { get; init; }
      public float ChHighInletPresureMin { get; init; }
      public float ChHighInletPresureMax { get; init; }

      public float ChHighOutletPresureAvg { get; init; }
      public float ChHighOutletPresureMin { get; init; }
      public float ChHighOutletPresureMax { get; init; }

      public byte Ch1Status { get; init; }

      public float Ch1LowInletTempAvg { get; init; }
      public float Ch1LowInletTempMin { get; init; }
      public float Ch1LowInletTempMax { get; init; }

      public float Ch1LowOutletTempAvg { get; init; }
      public float Ch1LowOutletTempMin { get; init; }
      public float Ch1LowOutletTempMax { get; init; }

      public float Ch1LowOutletPresureAvg { get; init; }
      public float Ch1LowOutletPresureMin { get; init; }
      public float Ch1LowOutletPresureMax { get; init; }

      public byte Ch2Status { get; init; }

      public float Ch2LowInletTempAvg { get; init; }
      public float Ch2LowInletTempMin { get; init; }
      public float Ch2LowInletTempMax { get; init; }

      public float Ch2LowOutletTempAvg { get; init; }
      public float Ch2LowOutletTempMin { get; init; }
      public float Ch2LowOutletTempMax { get; init; }

      public float Ch2LowOutletPresureAvg { get; init; }
      public float Ch2LowOutletPresureMin { get; init; }
      public float Ch2LowOutletPresureMax { get; init; }

      public byte DhwStatus { get; init; }

      public float DhwTempAvg { get; init; }
      public float DhwTempMin { get; init; }
      public float DhwTempMax { get; init; }
   }
}
