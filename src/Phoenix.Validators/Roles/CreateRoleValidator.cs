using FluentValidation;
using Phoenix.Models.Roles.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Roles
{
   public sealed class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
   {
      public CreateRoleValidator()
      {
         RuleFor(x => x.Name)
            .Length(3, 50).WithMessage(Translations.Validator_Name_Invalid);
      }
   }
}
