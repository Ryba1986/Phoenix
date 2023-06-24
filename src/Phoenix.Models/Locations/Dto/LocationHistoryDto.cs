using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Locations.Dto
{
   public sealed class LocationHistoryDto : HistoryDtoBase
   {
      public string Name { get; init; }
      public bool IncludeReport { get; init; }

      public LocationHistoryDto()
      {
         Name = string.Empty;
      }
   }
}
