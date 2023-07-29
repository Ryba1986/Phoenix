import { DefineLocaleMessage } from "vue-i18n";

export interface Language extends DefineLocaleMessage {
   components: {
      dataGrid: {
         columns: {
            createdBy: string;
            createDate: string;
            isActive: string;
         };
      };
      loadPanel: {
         message: string;
      };
      navbar: {
         client: string;
         dashboard: string;
         device: string;
         location: string;
         report: string;
         role: string;
         signIn: string;
         signOut: string;
         user: string;
      };
   };
   requests: {
      default: string;
      fileNameNotExists: string;
      forbidden: string;
      unauthorized: string;
      userNotFound: string;
   };
   views: {
      location: {
         grid: {
            columns: {
               name: string;
               includeReport: string;
            };
            validators: {
               name: {
                  length: string;
               };
            };
         };
      };
      report: {
         downloadButton: string;
         date: {
            requiredValidator: string;
         };
         type: {
            rangeValidator: string;
         };
      };
      signIn: {
         loginButton: string;
         email: {
            placeHolder: string;
            emailValidator: string;
            lengthValidator: string;
         };
         password: {
            placeHolder: string;
            lengthValidator: string;
         };
      };
   };
}
