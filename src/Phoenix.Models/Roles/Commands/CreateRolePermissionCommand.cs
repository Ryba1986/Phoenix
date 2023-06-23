using Phoenix.Models.Base.Commands;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Models.Roles.Commands
{
   public sealed class CreateRolePermissionCommand : CreateCommandBase
   {
      public int RoleId { get; init; }
      public Permission Permission { get; init; }
      public AccessLevel AccessLevel { get; init; }
   }
}
