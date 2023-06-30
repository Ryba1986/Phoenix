using System.Collections.Generic;
using System.Globalization;

namespace Phoenix.Shared.Languages
{
   public static class Translations
   {
      // Entities

      public static string Client_Exists => Get(eng: "Client exists.", pol: "Klient już istnieje.");
      public static string Client_NotExists => Get(eng: "Client not exists.", pol: "Klient nie istnieje.");

      public static string Device_Exists => Get(eng: "Device exists.", pol: "Urządzenie już istnieje.");
      public static string Device_NotExists => Get(eng: "Device not exists.", pol: "Urządzenie nie istnieje.");
      public static string Device_DeviceType_Invalid => Get(eng: "Device type is invalid.", pol: "Typ urządzenia jest nieprawidłowy.");

      public static string Location_Active_Limit => Get(eng: "The limit of active locations has been exceeded.", pol: "Limit aktywnych lokalizacji został przekroczony.");
      public static string Location_Exists => Get(eng: "Location exists.", pol: "Lokalizacja już istnieje.");
      public static string Location_NotExists => Get(eng: "Location not exists.", pol: "Lokalizacja nie istnieje.");

      public static string ReportType_Day => Get(eng: "Day", pol: "Dobowy");
      public static string ReportType_Month => Get(eng: "Month", pol: "Miesięczny");
      public static string ReportType_Year => Get(eng: "Year", pol: "Roczny");
      public static string ReportType_YearByDay => Get(eng: "Day of year", pol: "Dobowy roczny");

      public static string RolePermission_Exists => Get(eng: "Permission exists.", pol: "Uprawnienie już istnieje.");
      public static string RolePermission_NotExists => Get(eng: "Permission not exists.", pol: "Uprawnienie nie istnieje.");

      public static string Role_Exists => Get(eng: "Role exists.", pol: "Rola już istnieje.");
      public static string Role_NotExists => Get(eng: "Role not exists.", pol: "Rola nie istnieje.");

      public static string User_Active_NotExists => Get(eng: "Cannot find an active user.", pol: "Nie można znaleźć aktywnego użytkownika.");
      public static string User_Exists => Get(eng: "User exists.", pol: "Użytkownik już istnieje.");
      public static string User_NotExists => Get(eng: "User not exists.", pol: "Użytkownik nie istnieje.");

      // Enums

      public static string DeviceType_Meter => Get(eng: "Meter", pol: "Licznik ciepła");
      public static string DeviceType_Heating => Get(eng: "Heating", pol: "CO");
      public static string DeviceType_DoubleHeating => Get(eng: "Double heating", pol: "CO & CO");
      public static string DeviceType_HeatingDomestic => Get(eng: "Heating & domestic water", pol: "CO & CWU");

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

      // Validators

      public static string Validator_AccessLevel_Invalid => Get(eng: "Access level is invaild.", pol: "Poziom dostępu jest nieprawidłowy.");
      public static string Validator_BoundRate_Invalid => Get(eng: "Boundrate is invaild.", pol: "Prędkość jest nieprawidłowa.");
      public static string Validator_ClientVersion_Invalid => Get(eng: "Client version is invaild.", pol: "Wersja klienta jest nieprawidłowa.");
      public static string Validator_CurrentPassword_Invalid => Get(eng: "Current password is invaild.", pol: "Aktualne hasło jest nieprawidłowe.");
      public static string Validator_DataBits_Invalid => Get(eng: "Data bit is invaild.", pol: "Data bit jest nieprawidłowe.");
      public static string Validator_DeviceType_Invalid => Get(eng: "Device type is invaild.", pol: "Typ urządzenia jest nieprawidłowe.");
      public static string Validator_Email_Invalid => Get(eng: "Email is invaild.", pol: "Email jest nieprawidłowy.");
      public static string Validator_Hostname_Invalid => Get(eng: "Hostname is invaild.", pol: "Nazwa hosta jest nieprawidłowa.");
      public static string Validator_Id_Invalid => Get(eng: "Id is invaild.", pol: "Identyfikator jest nieprawidłowy.");
      public static string Validator_LocationId_Invalid => Get(eng: "Location is invaild.", pol: "Lokalizacja jest nieprawidłowa.");
      public static string Validator_MacAddress_Invalid => Get(eng: "MAC address is invaild.", pol: "Adres MAC jest nieprawidłowy.");
      public static string Validator_Name_Invalid => Get(eng: "Name is invaild.", pol: "Nazwa jest nieprawidłowa.");
      public static string Validator_NewPassword_Invalid => Get(eng: "New password is invaild.", pol: "Nowe hasło jest nieprawidłowe.");
      public static string Validator_Parity_Invalid => Get(eng: "Parity is invaild.", pol: "Parzystość jest nieprawidłowa.");
      public static string Validator_Permission_Invalid => Get(eng: "Permission is invaild.", pol: "Uprawnienie jest nieprawidłowe.");
      public static string Validator_PlcType_Invalid => Get(eng: "Plc type is invaild.", pol: "Typ plc jest nieprawidłowy.");
      public static string Validator_RoleId_Invalid => Get(eng: "Role is invaild.", pol: "Rola jest nieprawidłowa.");
      public static string Validator_StopBits_Invalid => Get(eng: "Stop bits is invaild.", pol: "Stop bit jest nieprawidłowy.");
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
