using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Users.Commands
{
   public sealed class CreateUserCommand : CreateCommandBase
   {
      public string Name { get; init; }
      public string Email { get; init; }
      public int RoleId { get; init; }

      public CreateUserCommand()
      {
         Name = string.Empty;
         Email = string.Empty;
      }
   }
}
