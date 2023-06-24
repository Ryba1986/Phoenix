using Phoenix.Entities.Base;

namespace Phoenix.Entities.Locations
{
   public sealed class LocationHistory : HistoryBase
   {
      public int LocationId { get; init; }
      public Location Location { get; init; }

      public string Name { get; init; }
      public bool IncludeReport { get; init; }

      public LocationHistory()
      {
         Location = null!;
         Name = string.Empty;
      }
   }
}
