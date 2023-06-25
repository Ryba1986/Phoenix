using FluentValidation;
using Phoenix.Models.Roles.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Roles
{
   public sealed class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
   {
      public UpdateRoleValidator()
      {
         RuleFor(x => x.Id)
            .NotEmpty().WithMessage(Translations.Validator_Id_Invalid);

         RuleFor(x => x.Name)
            .Length(3, 50).WithMessage(Translations.Validator_Name_Invalid);

         RuleFor(x => x.Version)
            .NotEmpty().WithMessage(Translations.Validator_Version_Invalid);
      }
   }
}
