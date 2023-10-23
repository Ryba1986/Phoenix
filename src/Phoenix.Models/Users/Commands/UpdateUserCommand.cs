using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Users.Commands
{
   public sealed class UpdateUserCommand : UpdateCommandBase
   {
      public int RoleId { get; init; }
      public string Name { get; init; }
      public string Email { get; init; }

      public UpdateUserCommand()
      {
         Name = string.Empty;
         Email = string.Empty;
      }
   }
}
