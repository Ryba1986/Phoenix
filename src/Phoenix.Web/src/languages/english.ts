import { Language } from "../models/languages/language";

export const english: Language = {
   components: {
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
