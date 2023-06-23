using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Roles.Commands
{
   public sealed class CreateRoleCommand : CreateCommandBase
   {
      public string Name { get; init; }

      public CreateRoleCommand()
      {
         Name = string.Empty;
      }
   }
}
