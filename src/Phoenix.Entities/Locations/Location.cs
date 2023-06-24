using System.Collections.Generic;
using Phoenix.Entities.Base;

namespace Phoenix.Entities.Locations
{
   public sealed class Location : MetricBase
   {
      public string Name { get; set; }
      public bool IncludeReport { get; set; }

      public ICollection<LocationHistory> History { get; }

      public Location()
      {
         Name = string.Empty;
         History = new List<LocationHistory>();
      }
   }
}
