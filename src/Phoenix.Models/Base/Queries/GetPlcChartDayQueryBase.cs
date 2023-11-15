using System;

namespace Phoenix.Models.Base.Queries
{
   public abstract class GetPlcChartDayQueryBase : GetPlcChartQueryBase
   {
      public DateTime EndDate { get; init; }
   }
}
