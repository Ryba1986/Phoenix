using Phoenix.Shared.Attributes;
using Phoenix.Shared.Languages;

namespace Phoenix.Shared.Enums.Devices
{
   public enum DeviceType : byte
   {
      [Localization(nameof(Translations.DeviceType_Meter))]
      Meter = 1,

      [Localization(nameof(Translations.DeviceType_Heating))]
      Heating = 10,

      [Localization(nameof(Translations.DeviceType_DoubleHeating))]
      DoubleHeating = 20,

      [Localization(nameof(Translations.DeviceType_HeatingDomestic))]
      HeatingDomestic = 30,
   }
}
