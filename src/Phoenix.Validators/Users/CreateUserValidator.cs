using FluentValidation;
using Phoenix.Models.Users.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Users
{
   public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
   {
      public CreateUserValidator()
      {
         RuleFor(x => x.Name)
            .Length(3, 50).WithMessage(Translations.Validator_Name_Invalid);

         RuleFor(x => x.Email)
            .Matches(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$").WithMessage(Translations.Validator_Email_Invalid)
            .MaximumLength(50).WithMessage(Translations.Validator_Email_Invalid);

         RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage(Translations.Validator_RoleId_Invalid);
      }
   }
}
