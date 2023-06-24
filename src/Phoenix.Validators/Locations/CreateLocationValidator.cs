using FluentValidation;
using Phoenix.Models.Locations.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Locations
{
   public sealed class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
   {
      public CreateLocationValidator()
      {
         RuleFor(x => x.Name)
            .NotEmpty().WithMessage(Translations.Validator_Name_Invalid)
            .Length(3, 30).WithMessage(Translations.Validator_Name_Invalid);
      }
   }
}
