using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Users.Commands
{
   public sealed class UpdateUserPasswordCommand : CommandBase
   {
      public string CurrentPassword { get; init; }
      public string NewPassword { get; init; }
      public string ConfirmNewPassword { get; init; }
      public int UserId { get; private set; }

      public UpdateUserPasswordCommand()
      {
         CurrentPassword = string.Empty;
         NewPassword = string.Empty;
         ConfirmNewPassword = string.Empty;
      }

      public override void SetId(int id)
      {
         UserId = id;
      }
   }
}
