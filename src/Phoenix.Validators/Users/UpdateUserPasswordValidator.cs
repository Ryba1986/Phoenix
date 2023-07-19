using FluentValidation;
using Phoenix.Models.Users.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Users
{
   public sealed class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordCommand>
   {
      public UpdateUserPasswordValidator()
      {
         RuleFor(x => x.CurrentPassword)
            .Length(10, 30).WithMessage(Translations.Validator_CurrentPassword_Invalid);

         RuleFor(x => x.NewPassword)
            .Length(10, 30).WithMessage(Translations.Validator_NewPassword_Invalid)
            .Equal(x => x.CurrentPassword).WithMessage(Translations.Validator_NewPassword_Invalid);

         RuleFor(x => x.ConfirmNewPassword)
            .NotEqual(x => x.NewPassword).WithMessage(Translations.Validator_ConfirmNewPassword_Invalid);

         RuleFor(x => x.UserId)
            .NotEmpty().WithMessage(Translations.Validator_UserId_Invalid);
      }
   }
}
