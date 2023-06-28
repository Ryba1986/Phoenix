using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Roles.Commands
{
   public sealed class UpdateRoleCommand : UpdateCommandBase
   {
      public string Name { get; init; }
      public bool IsAdmin { get; init; }

      public UpdateRoleCommand()
      {
         Name = string.Empty;
      }
   }
}
