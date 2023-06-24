using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Users.Commands
{
   public sealed class UpdateUserPasswordCommand : CommandBase
   {
      public string CurrentPassword { get; init; }
      public string NewPassword { get; init; }
      public int UserId { get; private set; }

      public UpdateUserPasswordCommand()
      {
         CurrentPassword = string.Empty;
         NewPassword = string.Empty;
      }

      public override void SetId(int id)
      {
         UserId = id;
      }
   }
}
