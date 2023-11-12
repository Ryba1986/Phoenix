using System;

namespace Phoenix.Models.Base.Queries
{
   public abstract class GetPlcChartQueryBase
   {
      public int DeviceId { get; init; }
      public DateOnly Date { get; init; }
   }
}
