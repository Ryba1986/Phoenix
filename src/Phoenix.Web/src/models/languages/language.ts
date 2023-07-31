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
         administration: string;
         client: string;
         dashboard: string;
         device: string;
         location: string;
         masterdata: string;
         report: string;
         role: string;
         rolePermission: string;
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
      client: {
         grid: {
            columns: {
               location: string;
               macAddress: string;
               hostname: string;
               clientVersion: string;
            };
            validators: {
               location: {
                  range: string;
               };
               macAddress: {
                  pattern: string;
               };
            };
         };
      };
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
      device: {
         grid: {
            columns: {
               boundRate: string;
               dataBits: string;
               parity: string;
               stopBits: string;
               includeReport: string;
               location: string;
               modbusId: string;
               name: string;
               deviceType: string;
               plcType: string;
            };
            validators: {
               boundRate: {
                  range: string;
               };
               dataBits: {
                  range: string;
               };
               parity: {
                  range: string;
               };
               stopBits: {
                  range: string;
               };
               location: {
                  range: string;
               };
               modbusId: {
                  range: string;
               };
               name: {
                  length: string;
               };
               deviceType: {
                  range: string;
               };
               plcType: {
                  range: string;
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
      role: {
         grid: {
            columns: {
               name: string;
               isAdmin: string;
            };
            validators: {
               name: {
                  length: string;
               };
            };
         };
      };
      rolePermission: {
         grid: {
            columns: {
               role: string;
               permission: string;
               accessLevel: string;
            };
            validators: {
               role: {
                  range: string;
               };
               permission: {
                  range: string;
               };
               accessLevel: {
                  range: string;
               };
            };
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
      user: {
         grid: {
            columns: {
               name: string;
               email: string;
               role: string;
            };
            validators: {
               name: {
                  length: string;
               };
               email: {
                  email: string;
                  length: string;
               };
               role: {
                  range: string;
               };
            };
         };
      };
   };
}
