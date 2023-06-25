using FluentValidation;
using Phoenix.Models.Clients.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Clients
{
   public sealed class CreateClientValidator : AbstractValidator<CreateClientCommand>
   {
      public CreateClientValidator()
      {
         RuleFor(x => x.LocationId)
            .NotEmpty().WithMessage(Translations.Validator_LocationId_Invalid);

         RuleFor(x => x.MacAddress)
            .NotEmpty().WithMessage(Translations.Validator_MacAddress_Invalid)
            .Matches("^[0-9A-F]{12}$").WithMessage(Translations.Validator_MacAddress_Invalid);
      }
   }
}
