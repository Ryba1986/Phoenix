using FluentValidation;
using Phoenix.Models.Clients.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Clients
{
   public sealed class UpdateClientInfoValidator : AbstractValidator<UpdateClientInfoCommand>
   {
      public UpdateClientInfoValidator()
      {
         RuleFor(x => x.Hostname)
            .NotNull().WithMessage(Translations.Validator_Hostname_Invalid)
            .MaximumLength(66).WithMessage(Translations.Validator_Hostname_Invalid);

         RuleFor(x => x.ClientVersion)
            .NotNull().WithMessage(Translations.Validator_ClientVersion_Invalid)
            .MaximumLength(20).WithMessage(Translations.Validator_ClientVersion_Invalid);
      }
   }
}
