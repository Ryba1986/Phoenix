using FluentValidation;
using Phoenix.Models.Users.Commands;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Validators;

namespace Phoenix.Validators.Users
{
   public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
   {
      public CreateUserValidator()
      {
         RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage(Translations.Validator_RoleId_Invalid);

         RuleFor(x => x.Name)
            .Length(3, 50).WithMessage(Translations.Validator_Name_Invalid);

         RuleFor(x => x.Email)
            .Matches(RegexPatterns.Email).WithMessage(Translations.Validator_Email_Invalid)
            .MaximumLength(50).WithMessage(Translations.Validator_Email_Invalid);
      }
   }
}
