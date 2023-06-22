using Phoenix.Shared.Attributes;
using Phoenix.Shared.Languages;

namespace Phoenix.Shared.Enums.Roles
{
   public enum Permission : byte
   {
      [Localization(nameof(Translations.RolePermission_Device))]
      Device = 1,

      [Localization(nameof(Translations.RolePermission_Location))]
      Location = 2,

      [Localization(nameof(Translations.RolePermission_Plc))]
      Plc = 3,

      [Localization(nameof(Translations.RolePermission_Report))]
      Report = 4,

      [Localization(nameof(Translations.RolePermission_Role))]
      Role = 5,

      [Localization(nameof(Translations.RolePermission_User))]
      User = 6,
   }
}
