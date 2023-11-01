namespace Phoenix.Shared.Languages
{
   public static partial class Translations
   {
      public static string DeviceType_Meter => Get(eng: "Meter", pol: "Licznik ciepła");
      public static string DeviceType_Heating => Get(eng: "Heating", pol: "CO");
      public static string DeviceType_DoubleHeating => Get(eng: "Double heating", pol: "CO & CO");
      public static string DeviceType_HeatingDomestic => Get(eng: "Heating & domestic water", pol: "CO & CWU");

      public static string PlcReportType_Day => Get(eng: "Day", pol: "Dobowy");
      public static string PlcReportType_Month => Get(eng: "Month", pol: "Miesięczny");
      public static string PlcReportType_Year => Get(eng: "Year", pol: "Roczny");
      public static string PlcReportType_YearByDay => Get(eng: "Day of year", pol: "Dobowy roczny");

      public static string RoleAccessLevel_None => Get(eng: "None", pol: "Brak");
      public static string RoleAccessLevel_Read => Get(eng: "Read", pol: "Odczyt");
      public static string RoleAccessLevel_Write => Get(eng: "Write", pol: "Zapis");

      public static string RolePermission_Client => Get(eng: "Clients", pol: "Klienci");
      public static string RolePermission_Device => Get(eng: "Devices", pol: "Urządzenia");
      public static string RolePermission_Location => Get(eng: "Locations", pol: "Lokalizacje");
      public static string RolePermission_Plc => Get(eng: "Plcs", pol: "Sterowniki");
      public static string RolePermission_Report => Get(eng: "Reports", pol: "Raporty");
      public static string RolePermission_Role => Get(eng: "Roles", pol: "Role");
      public static string RolePermission_User => Get(eng: "Users", pol: "Użytkownicy");

      public static string SerialParity_None => Get(eng: "None", pol: "Brak");
      public static string SerialParity_Odd => Get(eng: "Odd", pol: "Nieparzysty");
      public static string SerialParity_Even => Get(eng: "Even", pol: "Parzysty");
   }
}
