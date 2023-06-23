using Phoenix.Models.Base.Commands;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Models.Roles.Commands
{
   public sealed class UpdateRolePermissionCommand : UpdateCommandBase
   {
      public AccessLevel AccessLevel { get; init; }
   }
}
