using FluentValidation;
using Phoenix.Models.Users.Commands;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Validators;

namespace Phoenix.Validators.Users
{
   public sealed class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
   {
      public UpdateUserValidator()
      {
         RuleFor(x => x.Id)
            .NotEmpty().WithMessage(Translations.Validator_Id_Invalid);

         RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage(Translations.Validator_RoleId_Invalid);

         RuleFor(x => x.Name)
            .Length(3, 50).WithMessage(Translations.Validator_Name_Invalid);

         RuleFor(x => x.Email)
            .Matches(RegexPatterns.Email).WithMessage(Translations.Validator_Email_Invalid)
            .MaximumLength(50).WithMessage(Translations.Validator_Email_Invalid);

         RuleFor(x => x.Version)
            .NotEmpty().WithMessage(Translations.Validator_Version_Invalid);
      }
   }
}
