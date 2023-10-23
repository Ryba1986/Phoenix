using Phoenix.Shared.Attributes;
using Phoenix.Shared.Languages;

namespace Phoenix.Shared.Enums.Roles
{
   public enum Permission : byte
   {
      [Localization(nameof(Translations.RolePermission_Client))]
      Client = 1,

      [Localization(nameof(Translations.RolePermission_Device))]
      Device = 30,

      [Localization(nameof(Translations.RolePermission_Location))]
      Location = 60,

      [Localization(nameof(Translations.RolePermission_Plc))]
      Plc = 90,

      [Localization(nameof(Translations.RolePermission_Report))]
      Report = 120,

      [Localization(nameof(Translations.RolePermission_Role))]
      Role = 150,

      [Localization(nameof(Translations.RolePermission_User))]
      User = 180,
   }
}
