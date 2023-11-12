using FluentValidation;
using Phoenix.Models.Plcs.Meters.Commands;

namespace Phoenix.Validators.Plcs.Meters
{
   public sealed class CreateKamstrupValidator : AbstractValidator<CreateKamstrupCommand>
   {
      public CreateKamstrupValidator()
      {
         RuleFor(x => x.DeviceId).NotEmpty();

         RuleFor(x => x.Date).NotEmpty();

         RuleFor(x => x.SerialNumber).NotNull();
      }
   }
}
