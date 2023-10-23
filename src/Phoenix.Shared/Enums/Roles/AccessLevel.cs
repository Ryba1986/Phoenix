using Phoenix.Shared.Attributes;
using Phoenix.Shared.Languages;

namespace Phoenix.Shared.Enums.Roles
{
   public enum AccessLevel : byte
   {
      [Localization(nameof(Translations.RoleAccessLevel_None))]
      None = 0,

      [Localization(nameof(Translations.RoleAccessLevel_Read))]
      Read = 50,

      [Localization(nameof(Translations.RoleAccessLevel_Write))]
      Write = 100,
   }
}
