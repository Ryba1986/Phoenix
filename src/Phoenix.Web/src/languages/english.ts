import { Language } from "../models/languages/language";

export const english: Language = {
   components: {
      dataGrid: {
         columns: {
            createdBy: "Created by",
            createDate: "Create date",
            isActive: "Active",
         },
      },
      loadPanel: {
         message: "Loading ...",
      },
      navbar: {
         client: "Clients",
         dashboard: "Dashboard",
         device: "Devices",
         location: "Locations",
         report: "Reports",
         role: "Roles",
         signIn: "Sign in",
         signOut: "Sign out",
         user: "Users",
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
      signIn: {
         loginButton: "Login",
         email: {
            placeHolder: "Enter email address.",
            emailValidator: "Email is invalid.",
            lengthValidator: "Email must contain a maximum of 50 symbols.",
         },
         password: {
            placeHolder: "Enter password.",
            lengthValidator: "Password must be between 10 and 30 symbols.",
         },
      },
   },
};
