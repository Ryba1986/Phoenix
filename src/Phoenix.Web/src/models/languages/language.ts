import { DefineLocaleMessage } from "vue-i18n";

export interface Language extends DefineLocaleMessage {
   components: {
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
   views: {};
}
