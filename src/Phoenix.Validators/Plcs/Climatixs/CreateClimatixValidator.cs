using FluentValidation;
using Phoenix.Models.Plcs.Climatixs.Commands;

namespace Phoenix.Validators.Plcs.Climatixs
{
   public sealed class CreateClimatixValidator : AbstractValidator<CreateClimatixCommand>
   {
      public CreateClimatixValidator()
      {
         RuleFor(x => x.DeviceId).NotEmpty();

         RuleFor(x => x.Date).NotEmpty();

         RuleFor(x => x.SerialNumber).NotNull();
      }
   }
}
