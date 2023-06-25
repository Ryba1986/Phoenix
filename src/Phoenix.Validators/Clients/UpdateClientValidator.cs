using FluentValidation;
using Phoenix.Models.Clients.Commands;
using Phoenix.Shared.Languages;

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
            .Matches("^[0-9A-F]{12}$").WithMessage(Translations.Validator_MacAddress_Invalid);

         RuleFor(x => x.Version)
            .NotEmpty().WithMessage(Translations.Validator_Version_Invalid);
      }
   }
}
