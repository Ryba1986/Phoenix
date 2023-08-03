using FluentValidation;
using Phoenix.Models.Clients.Commands;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Validators;

namespace Phoenix.Validators.Clients
{
   public sealed class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
   {
      public UpdateClientValidator()
      {
         RuleFor(x => x.Id)
            .NotEmpty().WithMessage(Translations.Validator_Id_Invalid);

         RuleFor(x => x.LocationId)
            .NotEmpty().WithMessage(Translations.Validator_LocationId_Invalid);

         RuleFor(x => x.MacAddress)
            .NotEmpty().WithMessage(Translations.Validator_MacAddress_Invalid)
            .Matches(RegexPatterns.MacAddress).WithMessage(Translations.Validator_MacAddress_Invalid);
      }
   }
}
