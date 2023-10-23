using FluentValidation;
using Phoenix.Models.Plcs.Rvds.Commands;

namespace Phoenix.Validators.Plcs.Rvds
{
   public sealed class CreateRvd145Validator : AbstractValidator<CreateRvd145Command>
   {
      public CreateRvd145Validator()
      {
         RuleFor(x => x.Date).NotEmpty();

         RuleFor(x => x.DeviceId).NotEmpty();

         RuleFor(x => x.SerialNumber).NotNull();
      }
   }
}
