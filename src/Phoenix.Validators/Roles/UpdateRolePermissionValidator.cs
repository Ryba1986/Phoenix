using FluentValidation;
using Phoenix.Models.Roles.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Roles
{
   public sealed class UpdateRolePermissionValidator : AbstractValidator<UpdateRolePermissionCommand>
   {
      public UpdateRolePermissionValidator()
      {
         RuleFor(x => x.Id)
            .NotEmpty().WithMessage(Translations.Validator_Id_Invalid);

         RuleFor(x => x.AccessLevel)
            .IsInEnum().WithMessage(Translations.Validator_AccessLevel_Invalid);
      }
   }
}
