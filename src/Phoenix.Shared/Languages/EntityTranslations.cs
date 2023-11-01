namespace Phoenix.Shared.Languages
{
   public static partial class Translations
   {
      public static string Client_Exists => Get(eng: "Client exists.", pol: "Klient już istnieje.");
      public static string Client_NotExists => Get(eng: "Client not exists.", pol: "Klient nie istnieje.");

      public static string Device_Exists => Get(eng: "Device exists.", pol: "Urządzenie już istnieje.");
      public static string Device_NotExists => Get(eng: "Device not exists.", pol: "Urządzenie nie istnieje.");
      public static string Device_DeviceType_Invalid => Get(eng: "Device type is invalid.", pol: "Typ urządzenia jest nieprawidłowy.");

      public static string Location_Active_Limit => Get(eng: "The limit of active locations has been exceeded.", pol: "Limit aktywnych lokalizacji został przekroczony.");
      public static string Location_Exists => Get(eng: "Location exists.", pol: "Lokalizacja już istnieje.");
      public static string Location_NotExists => Get(eng: "Location not exists.", pol: "Lokalizacja nie istnieje.");

      public static string Role_Exists => Get(eng: "Role exists.", pol: "Rola już istnieje.");
      public static string Role_NotExists => Get(eng: "Role not exists.", pol: "Rola nie istnieje.");

      public static string RolePermission_Exists => Get(eng: "Permission exists.", pol: "Uprawnienie już istnieje.");
      public static string RolePermission_NotExists => Get(eng: "Permission not exists.", pol: "Uprawnienie nie istnieje.");

      public static string User_Active_NotExists => Get(eng: "Cannot find an active user.", pol: "Nie można znaleźć aktywnego użytkownika.");
      public static string User_Exists => Get(eng: "User exists.", pol: "Użytkownik już istnieje.");
      public static string User_NotExists => Get(eng: "User not exists.", pol: "Użytkownik nie istnieje.");
   }
}
