using Phoenix.Models.Base.Dto;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Models.Roles.Dto
{
   public sealed class RolePermissionDto : MetricDtoBase
   {
      public int RoleId { get; init; }
      public Permission Permission { get; init; }
      public AccessLevel AccessLevel { get; init; }
   }
}
