using System;

namespace Phoenix.Models.Base.Queries
{
   public abstract class GetPlcChartQueryBase
   {
      public DateTime StartDate { get; init; }
      public int DeviceId { get; init; }
   }
}
