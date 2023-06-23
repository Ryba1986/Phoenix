using FluentValidation;
using Phoenix.Models.Roles.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Roles
{
   public sealed class CreateRolePermissionValidator : AbstractValidator<CreateRolePermissionCommand>
   {
      public CreateRolePermissionValidator()
      {
         RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage(Translations.Validator_RoleId_Invalid);

         RuleFor(x => x.Permission)
            .IsInEnum().WithMessage(Translations.Validator_Permission_Invalid);

         RuleFor(x => x.AccessLevel)
            .IsInEnum().WithMessage(Translations.Validator_AccessLevel_Invalid);
      }
   }
}
