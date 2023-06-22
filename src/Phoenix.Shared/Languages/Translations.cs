using System.Collections.Generic;
using System.Globalization;

namespace Phoenix.Shared.Languages
{
   public static class Translations
   {
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
