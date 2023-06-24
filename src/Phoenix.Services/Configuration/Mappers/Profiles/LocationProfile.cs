using AutoMapper;
using Phoenix.Entities.Locations;
using Phoenix.Models.Locations.Dto;

namespace Phoenix.Services.Configuration.Mappers.Profiles
{
   internal sealed class LocationProfile : Profile
   {
      public LocationProfile()
      {
         CreateProjection<Location, LocationDto>();
         CreateProjection<LocationHistory, LocationHistoryDto>();
      }
   }
}
