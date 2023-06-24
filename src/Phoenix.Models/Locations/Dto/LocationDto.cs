using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Locations.Dto
{
   public sealed class LocationDto : MetricDtoBase
   {
      public string Name { get; init; }
      public bool IncludeReport { get; init; }

      public LocationDto()
      {
         Name = string.Empty;
      }
   }
}
