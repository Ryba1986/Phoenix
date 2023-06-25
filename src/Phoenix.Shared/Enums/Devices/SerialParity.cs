using Phoenix.Shared.Attributes;
using Phoenix.Shared.Languages;

namespace Phoenix.Shared.Enums.Devices
{
   public enum SerialParity : byte
   {
      [Localization(nameof(Translations.SerialParity_None))]
      None = 0,

      [Localization(nameof(Translations.SerialParity_Odd))]
      Odd = 1,

      [Localization(nameof(Translations.SerialParity_Even))]
      Even = 2
   }
}
