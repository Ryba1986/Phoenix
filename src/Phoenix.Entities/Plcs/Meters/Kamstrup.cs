using Phoenix.Entities.Base;

namespace Phoenix.Entities.Plcs.Meters
{
   public sealed class Kamstrup : PlcBase
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
