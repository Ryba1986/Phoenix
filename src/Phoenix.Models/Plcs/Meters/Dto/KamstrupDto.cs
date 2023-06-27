using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Plcs.Meters.Dto
{
   public sealed class KamstrupDto : PlcDtoBase
   {
      public float InletTemp { get; init; }
      public float OutletTemp { get; init; }
      public float Power { get; init; }
      public float Volume { get; init; }
      public float VolumeSummary { get; init; }
      public float EnergySummary { get; init; }
      public int HourCount { get; init; }
      public short ErrorCode { get; init; }
   }
}
