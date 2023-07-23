import { DefineLocaleMessage } from "vue-i18n";

export interface Language extends DefineLocaleMessage {
   components: {};
   requests: {
      default: string;
      fileNameNotExists: string;
      forbidden: string;
      unauthorized: string;
      userNotFound: string;
   };
   views: {};
}
