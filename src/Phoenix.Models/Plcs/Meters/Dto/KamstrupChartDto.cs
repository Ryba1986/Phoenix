using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Plcs.Meters.Dto
{
   public sealed class KamstrupChartDto : PlcChartDtoBase
   {
      public float InletTemp { get; init; }
      public float OutletTemp { get; init; }
      public float Power { get; init; }
      public float Volume { get; init; }
   }
}
