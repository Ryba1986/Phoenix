using AutoMapper;
using Phoenix.Entities.Roles;
using Phoenix.Models.Roles.Dto;

namespace Phoenix.Services.Configuration.Mappers.Profiles
{
   internal sealed class RoleProfile : Profile
   {
      public RoleProfile()
      {
         CreateProjection<Role, RoleDto>();

         CreateProjection<RolePermission, RolePermissionDto>();
      }
   }
}
