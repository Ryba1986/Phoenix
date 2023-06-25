using AutoMapper;
using Phoenix.Entities.Clients;
using Phoenix.Models.Clients.Dto;

namespace Phoenix.Services.Configuration.Mappers.Profiles
{
   internal sealed class ClientProfile : Profile
   {
      public ClientProfile()
      {
         CreateProjection<Client, ClientDto>();

         CreateProjection<ClientHistory, ClientHistoryDto>()
            .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Location != null ? src.Location.Name : string.Empty));
      }
   }
}
