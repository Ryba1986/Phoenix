import { Language } from "../models/languages/language";

export const pl: Language = {
   components: {
      climatix: {
         circulation: "Cyrkulacja",
         ch: "Ogrzewanie",
         ch1Short: "CO1",
         ch2Short: "CO2",
         dhwShort: "CWU",
         ch1HeatCurveTemp: "CO1 - krzywa grzania temp",
         ch1HighOutletTemp: "CO1 - wejście powrót temp",
         ch1LowInletTemp: "CO1 - wyjście zasilanie temp",
         ch1LowOutletTemp: "CO1 - wyjście powrót temp",
         ch1LowOutletPresure: "CO1 - wyjście powrót ciśnienie",
         ch2HeatCurveTemp: "CO2 - krzywa grzania temp",
         ch2HighOutletTemp: "CO2 - wejście powrót temp",
         ch2LowInletTemp: "CO2 - wyjście zasilanie temp",
         ch2LowOutletTemp: "CO2 - wyjście powrót temp",
         ch2LowOutletPresure: "CO2 - wyjście powrót ciśnienie",
         chHighInletPresure: "Sieć - zasilanie ciśnienie",
         chHighOutletPresure: "Sieć - powrót ciśnienie",
         dhwTemp: "Ciepła woda - temp",
         dhwTempSet: "Ciepła woda - zadana temp",
         network: "Sieć",
         outsideTemp: "Temp zewnętrzna",
         waterCold: "Zimna woda",
         waterWarm: "Ciepła woda",
      },
      dataGrid: {
         columns: {
            createdBy: "Utworzył",
            createDate: "Data utworzenia",
            isActive: "Aktywny",
         },
      },
      loadPanel: {
         message: "Ładowanie ...",
      },
      navbar: {
         administration: "Administracja",
         client: "Klienci",
         dashboard: "Wizualizacja",
         device: "Urządzenia",
         location: "Lokalizacje",
         masterdata: "Konfiguracja",
         report: "Raporty",
         role: "Role",
         rolePermission: "Uprawnienia",
         signIn: "Zaloguj",
         signOut: "Wyloguj",
         user: "Użytkownicy",
      },
   },
   requests: {
      default: "Wystąpił błąd podczas wykonywania operacji.",
      fileNameNotExists: "Nazwa pliku nie istnieje.",
      forbidden: "Brak uprawnień do wykonania tej operacji.",
      unauthorized: "Nie jesteś zalogowany.",
      userNotFound: "Użytkownik nie istnieje.",
   },
   views: {
      client: {
         grid: {
            columns: {
               location: "Lokalizacja",
               macAddress: "Adres MAC",
               hostname: "Nazwa hosta",
               clientVersion: "Wersja klienta",
            },
            validators: {
               location: {
                  range: "Lokalizacja jest wymagana.",
               },
               macAddress: {
                  pattern: "Adres MAC jest nieprawidłowy.",
               },
            },
         },
      },
      dashboard: {
         emptyData: "Lokalizacja nie została skonfigurowana lub nie zawiera żadnych danych.",
      },
      device: {
         grid: {
            columns: {
               boundRate: "Prędkość",
               dataBits: "Bity danych",
               parity: "Parzystość",
               stopBits: "Bity stopu",
               includeReport: "Raport",
               location: "Lokalizacja",
               modbusId: "Modbus ID",
               name: "Nazwa",
               deviceType: "Typ urządzenia",
               plcType: "Typ sterownika",
            },
            validators: {
               boundRate: {
                  range: "Prędkość jest wymagana.",
               },
               dataBits: {
                  range: "Bity danych są wymagane.",
               },
               parity: {
                  range: "Parzystość jest wymagana.",
               },
               stopBits: {
                  range: "Bity stopu są wymagane.",
               },
               location: {
                  range: "Lokalizacja jest wymagana.",
               },
               modbusId: {
                  range: "Modbus ID jest wymagany",
               },
               name: {
                  length: "Nazwa musi mieć od 3 do 30 znaków.",
               },
               deviceType: {
                  range: "Typ urządzenia jest wymagany.",
               },
               plcType: {
                  range: "Typ sterownika jest wymagany.",
               },
            },
         },
      },
      location: {
         grid: {
            columns: {
               name: "Nazwa",
               includeReport: "Raport",
            },
            validators: {
               name: {
                  length: "Nazwa musi mieć od 3 do 30 znaków.",
               },
            },
         },
      },
      report: {
         downloadButton: "Pobierz",
         date: {
            requiredValidator: "Data jest wymagana.",
         },
         type: {
            rangeValidator: "Typ jest wymagany.",
         },
      },
      role: {
         grid: {
            columns: {
               name: "Nazwa",
               isAdmin: "Admin",
            },
            validators: {
               name: {
                  length: "Nazwa musi mieć od 3 do 50 znaków.",
               },
            },
         },
      },
      rolePermission: {
         grid: {
            columns: {
               role: "Rola",
               permission: "Uprawnienie",
               accessLevel: "Poziom dostępu",
            },
            validators: {
               role: {
                  range: "Rola jest wymagana.",
               },
               permission: {
                  range: "Uprawnienie jest wymagane.",
               },
               accessLevel: {
                  range: "Poziom dostępu jest wymagany.",
               },
            },
         },
      },
      signIn: {
         loginButton: "Zaloguj",
         email: {
            placeHolder: "Wprowadź adres email.",
            emailValidator: "Email jest nieprawidłowy.",
            lengthValidator: "Wiadomość e-mail może zawierać maksymalnie 50 znaków.",
         },
         password: {
            placeHolder: "Wprowadź hasło.",
            lengthValidator: "Hasło musi zawierać od 10 do 30 znaków.",
         },
      },
      user: {
         grid: {
            columns: {
               name: "Nazwa",
               email: "Email",
               role: "Rola",
            },
            validators: {
               name: {
                  length: "Nazwa musi mieć od 3 do 30 znaków.",
               },
               email: {
                  email: "Email jest nieprawidłowy.",
                  length: "Email musi mieć od 3 do 50 znaków.",
               },
               role: {
                  range: "Rola jest wymagana.",
               },
            },
         },
      },
   },
};
