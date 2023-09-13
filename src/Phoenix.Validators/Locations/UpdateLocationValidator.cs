using FluentValidation;
using Phoenix.Models.Locations.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Locations
{
   public sealed class UpdateLocationValidator : AbstractValidator<UpdateLocationCommand>
   {
      public UpdateLocationValidator()
      {
         RuleFor(x => x.Id)
            .NotEmpty().WithMessage(Translations.Validator_Id_Invalid);

         RuleFor(x => x.Name)
            .NotEmpty().WithMessage(Translations.Validator_Name_Invalid)
            .Length(3, 30).WithMessage(Translations.Validator_Name_Invalid);

         RuleFor(x => x.Version)
            .NotEmpty().WithMessage(Translations.Validator_Version_Invalid);
      }
   }
}
