using Phoenix.Entities.Roles;
using Phoenix.Models.Roles.Dto;

namespace Phoenix.Services.Mappings
{
   internal static class RoleMappings
   {
      public static RoleDto ToRoleDto(this Role role)
      {
         return new()
         {
            Id = role.Id,
            Name = role.Name,
            IsAdmin = role.IsAdmin,
            IsActive = role.IsActive,
            Version = role.Version,
         };
      }

      public static RoleHistoryDto ToRoleHistoryDto(this RoleHistory roleHistory)
      {
         return new()
         {
            Id = roleHistory.Id,
            Name = roleHistory.Name,
            IsAdmin = roleHistory.IsAdmin,
            IsActive = roleHistory.IsActive,
            CreatedByName = roleHistory.CreatedBy.Name,
            CreateDate = roleHistory.CreateDate,
         };
      }

      public static RolePermissionDto ToRolePermissionDto(this RolePermission rolePermission)
      {
         return new()
         {
            Id = rolePermission.Id,
            RoleId = rolePermission.RoleId,
            Permission = rolePermission.Permission,
            AccessLevel = rolePermission.AccessLevel,
            IsActive = rolePermission.IsActive,
            Version = rolePermission.Version,
         };
      }
   }
}
