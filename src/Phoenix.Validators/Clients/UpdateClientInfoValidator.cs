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
            .NotEmpty().WithMessage(Translations.Validator_Hostname_Invalid)
            .Length(60, 66).WithMessage(Translations.Validator_Hostname_Invalid);

         RuleFor(x => x.ClientVersion)
            .NotEmpty().WithMessage(Translations.Validator_ClientVersion_Invalid)
            .Length(3, 20).WithMessage(Translations.Validator_ClientVersion_Invalid);
      }
   }
}
