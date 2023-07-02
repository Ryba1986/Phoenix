using System;

namespace Phoenix.Models.Base.Queries
{
   public abstract class GetPlcChartQueryBase
   {
      public DateOnly Date { get; init; }
      public int DeviceId { get; init; }
   }
}
