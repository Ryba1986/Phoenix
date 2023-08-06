import { Language } from "../models/languages/language";

export const en: Language = {
   components: {
      climatix: {
         circulation: "Circulation",
         ch: "Heating",
         ch1Short: "CH1",
         ch2Short: "CH2",
         dhwShort: "DHW",
         ch1HeatCurveTemp: "Heating 1 - heat curve",
         ch1LowInletTemp: "Heating 1 - low inlet",
         ch1LowOutletTemp: "CHeating 1 - low outlet",
         ch1LowOutletPresure: "Heating 1 - low outlet",
         ch2HeatCurveTemp: "Heating 2 - heat curve",
         ch2LowInletTemp: "Heating 2 - low inlet",
         ch2LowOutletTemp: "Heating 2 - low outlet",
         ch2LowOutletPresure: "Heating 2 - low outlet",
         chHighInletPresure: "Network - inlet",
         chHighOutletPresure: "Network - outlet",
         dhwTemp: "Domestic",
         dhwTempSet: "Domestic - set",
         network: "Network",
         outsideTemp: "Outside",
         waterCold: "Cold water",
         waterWarm: "Warm water",
      },
      dataGrid: {
         columns: {
            createdBy: "Created by",
            createDate: "Create date",
            isActive: "Active",
         },
      },
      kamstrup: {
         energySummary: "Summary energy",
         hourCount: "Working time",
         inletTemp: "Inlet temp",
         outletTemp: "Outlet temp",
         power: "Power",
         volume: "Volume",
         volumeSummary: "Summary volume",
      },
      loadPanel: {
         message: "Loading ...",
      },
      navbar: {
         administration: "Administration",
         client: "Clients",
         dashboard: "Dashboard",
         device: "Devices",
         location: "Locations",
         masterdata: "Masterdata",
         report: "Reports",
         role: "Roles",
         rolePermission: "Permissions",
         signIn: "Sign in",
         signOut: "Sign out",
         user: "Users",
      },
      rvd145: {
         circulation: "Circulation",
         ch: "Heating",
         chShort: "CH",
         dhwShort: "DHW",
         ch1HeatCurveTemp: "Heating - set",
         ch1HighOutletTemp: "Heating - high inlet",
         ch1LowInletTemp: "Heating - low inlet",
         ch1LowOutletPresure: "Heating - low outlet",
         chHighInletPresure: "Network - high inlet",
         dhwCirculationTemp: "Domestic - circulation",
         dhwTemp: "Domestic",
         dhwTempSet: "Domestic - set",
         network: "Network",
         outsideTemp: "Outside",
         waterCold: "Cold water",
         waterWarm: "Warm water",
      },
   },
   requests: {
      default: "An error occurred while executing the operation.",
      fileNameNotExists: "File name not exists.",
      forbidden: "You are not authorized to perform this operation.",
      unauthorized: "You are not authorized.",
      userNotFound: "User not found.",
   },
   views: {
      client: {
         grid: {
            columns: {
               location: "Location",
               macAddress: "MAC address",
               hostname: "Hostname",
               clientVersion: "Client version",
            },
            validators: {
               location: {
                  range: "Location is required.",
               },
               macAddress: {
                  pattern: "MAC address is invaild.",
               },
            },
         },
      },
      dashboard: {
         emptyData: "The location has not been configured or does not contain any data.",
      },
      device: {
         grid: {
            columns: {
               boundRate: "Bound rate",
               dataBits: "Data bits",
               parity: "Parity",
               stopBits: "Stop bits",
               includeReport: "Report",
               location: "Location",
               modbusId: "Modbus ID",
               name: "Name",
               deviceType: "Device type",
               plcType: "Plc type",
            },
            validators: {
               boundRate: {
                  range: "Bound rate is required.",
               },
               dataBits: {
                  range: "Data bits is required.",
               },
               parity: {
                  range: "Parity is required.",
               },
               stopBits: {
                  range: "Stop bits is required.",
               },
               location: {
                  range: "Location is required.",
               },
               modbusId: {
                  range: "Modbus ID is required.",
               },
               name: {
                  length: "Name must have between 3 and 30 characters.",
               },
               deviceType: {
                  range: "Device type is required.",
               },
               plcType: {
                  range: "Plc type is required.",
               },
            },
         },
      },
      location: {
         grid: {
            columns: {
               name: "Name",
               includeReport: "Report",
            },
            validators: {
               name: {
                  length: "Name must have between 3 and 30 characters.",
               },
            },
         },
      },
      report: {
         downloadButton: "Download",
         date: {
            requiredValidator: "Date is required.",
         },
         type: {
            rangeValidator: "Type is required.",
         },
      },
      role: {
         grid: {
            columns: {
               name: "Name",
               isAdmin: "Admin",
            },
            validators: {
               name: {
                  length: "Name must have between 3 and 50 characters.",
               },
            },
         },
      },
      rolePermission: {
         grid: {
            columns: {
               role: "Role",
               permission: "Permission",
               accessLevel: "Access level",
            },
            validators: {
               role: {
                  range: "Role is required.",
               },
               permission: {
                  range: "Permission is required.",
               },
               accessLevel: {
                  range: "Access level is required.",
               },
            },
         },
      },
      signIn: {
         loginButton: "Login",
         email: {
            placeHolder: "Enter email address.",
            emailValidator: "Email is invalid.",
            lengthValidator: "Email must contain a maximum of 50 characters.",
         },
         password: {
            placeHolder: "Enter password.",
            lengthValidator: "Password must be between 10 and 30 characters.",
         },
      },
      user: {
         grid: {
            columns: {
               name: "Name",
               email: "Email",
               role: "Role",
            },
            validators: {
               name: {
                  length: "Name must have between 3 and 30 characters.",
               },
               email: {
                  email: "Email is invalid.",
                  length: "Email must have between 3 and 50 characters.",
               },
               role: {
                  range: "Role is required.",
               },
            },
         },
      },
   },
};
