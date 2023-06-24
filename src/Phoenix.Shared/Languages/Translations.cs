using System.Collections.Generic;
using System.Globalization;

namespace Phoenix.Shared.Languages
{
   public static class Translations
   {
      // Entities

      public static string RolePermission_Exists => Get(eng: "Permission exists.", pol: "Uprawnienie już istnieje.");
      public static string RolePermission_NotExists => Get(eng: "Permission not exists.", pol: "Uprawnienie nie istnieje.");

      public static string Role_Exists => Get(eng: "Role exists.", pol: "Rola już istnieje.");
      public static string Role_NotExists => Get(eng: "Role not exists.", pol: "Rola nie istnieje.");

      public static string User_Exists => Get(eng: "User exists.", pol: "Użytkownik już istnieje.");
      public static string User_NotExists => Get(eng: "User not exists.", pol: "Użytkownik nie istnieje.");

      // Enums

      public static string RoleAccessLevel_None => Get(eng: "None", pol: "Brak");
      public static string RoleAccessLevel_Read => Get(eng: "Read", pol: "Odczyt");
      public static string RoleAccessLevel_Write => Get(eng: "Write", pol: "Zapis");

      public static string RolePermission_Device => Get(eng: "Devices", pol: "Urządzenia");
      public static string RolePermission_Location => Get(eng: "Locations", pol: "Lokalizacje");
      public static string RolePermission_Plc => Get(eng: "Plcs", pol: "Sterowniki");
      public static string RolePermission_Report => Get(eng: "Reports", pol: "Raporty");
      public static string RolePermission_Role => Get(eng: "Roles", pol: "Role");
      public static string RolePermission_User => Get(eng: "Users", pol: "Użytkownicy");

      // Validators

      public static string Validator_AccessLevel_Invalid => Get(eng: "Access level is invaild.", pol: "Poziom dostępu jest nieprawidłowy.");
      public static string Validator_CurrentPassword_Invalid => Get(eng: "Current password is invaild.", pol: "Aktualne hasło jest nieprawidłowe.");
      public static string Validator_Email_Invalid => Get(eng: "Email is invaild.", pol: "Email jest nieprawidłowy.");
      public static string Validator_Id_Invalid => Get(eng: "Id is invaild.", pol: "Identyfikator jest nieprawidłowy.");
      public static string Validator_Name_Invalid => Get(eng: "Name is invaild.", pol: "Nazwa jest nieprawidłowa.");
      public static string Validator_NewPassword_Invalid => Get(eng: "New password is invaild.", pol: "Nowe hasło jest nieprawidłowe.");
      public static string Validator_Permission_Invalid => Get(eng: "Permission is invaild.", pol: "Uprawnienie jest nieprawidłowe.");
      public static string Validator_RoleId_Invalid => Get(eng: "Role is invaild.", pol: "Rola jest nieprawidłowa.");
      public static string Validator_UserId_Invalid => Get(eng: "User is invaild.", pol: "Użytkownik jest nieprawidłowy.");
      public static string Validator_Version_Invalid => Get(eng: "The object has been modified.", pol: "Obiekt został zmodyfikowany.");

      // Languages

      public static CultureInfo GetDefaultCulture()
      {
         return new(English);
      }

      public static IReadOnlyCollection<CultureInfo> GetSupportedCultures()
      {
         return new CultureInfo[]{
            GetDefaultCulture(),
            new(Polish)
         };
      }

      private const string English = "en-US";
      private const string Polish = "pl-PL";

      private static string Get(string eng, string pol)
      {
         return CultureInfo.CurrentCulture.Name switch
         {
            English => eng,
            Polish => pol,
            _ => eng
         };
      }
   }
}
