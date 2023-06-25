using FluentValidation;
using Phoenix.Models.Devices.Commands;
using Phoenix.Shared.Languages;

namespace Phoenix.Validators.Devices
{
   public sealed class CreateDeviceValidator : AbstractValidator<CreateDeviceCommand>
   {
      public CreateDeviceValidator()
      {
         RuleFor(x => x.LocationId)
            .NotEmpty().WithMessage(Translations.Validator_LocationId_Invalid);

         RuleFor(x => x.Name)
            .NotEmpty().WithMessage(Translations.Validator_Name_Invalid)
            .Length(3, 30).WithMessage(Translations.Validator_Name_Invalid);

         RuleFor(x => x.DeviceType)
            .IsInEnum().WithMessage(Translations.Validator_DeviceType_Invalid);

         RuleFor(x => x.PlcType)
            .IsInEnum().WithMessage(Translations.Validator_PlcType_Invalid);

         RuleFor(x => x.BoundRate)
            .IsInEnum().WithMessage(Translations.Validator_BoundRate_Invalid);

         RuleFor(x => x.DataBits)
            .IsInEnum().WithMessage(Translations.Validator_DataBits_Invalid);

         RuleFor(x => x.Parity)
            .IsInEnum().WithMessage(Translations.Validator_Parity_Invalid);

         RuleFor(x => x.StopBits)
            .IsInEnum().WithMessage(Translations.Validator_StopBits_Invalid);
      }
   }
}
