using AutoMapper;
using Phoenix.Entities.Users;
using Phoenix.Models.Users.Dto;

namespace Phoenix.Services.Configuration.Mappers.Profiles
{
   internal sealed class UserProfile : Profile
   {
      public UserProfile()
      {
         CreateProjection<User, UserDto>();
      }
   }
}
