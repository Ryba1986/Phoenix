using FluentValidation;
using Phoenix.Models.Clients.Commands;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Validators;

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
            .Matches(RegexPatterns.MacAddress).WithMessage(Translations.Validator_MacAddress_Invalid);
      }
   }
}
