using Phoenix.Entities.Locations;
using Phoenix.Models.Locations.Dto;

namespace Phoenix.Services.Mappings
{
   internal static class LocationMappings
   {
      public static LocationDto ToLocationDto(this Location location)
      {
         return new()
         {
            Id = location.Id,
            Name = location.Name,
            IncludeReport = location.IncludeReport,
            IsActive = location.IsActive,
            Version = location.Version,
         };
      }

      public static LocationHistoryDto ToLocationHistoryDto(this LocationHistory locationHistory)
      {
         return new()
         {
            Id = locationHistory.Id,
            Name = locationHistory.Name,
            IncludeReport = locationHistory.IncludeReport,
            IsActive = locationHistory.IsActive,
            CreatedByName = locationHistory.CreatedBy.Name,
            CreateDate = locationHistory.CreateDate,
         };
      }
   }
}
