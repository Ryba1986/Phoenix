import { Routes } from "../models/routers/routes";

export const apiRequestContentType: string = "application/json";
export const apiTokenEmptyValue: string = "";
export const apiTokenName: string = "ApiToken";
export const apiTokenRefreshInterval: number = 60_000;
export const apiUrlBase: string = "/apiweb/";

export const dateFormat: string = "yyyy-MM-dd";
export const dateTimeFormat: string = "yyyy-MM-dd HH:mm:ss";
export const dateTimeShortFormat: string = "yyyy-MM-dd HH:mm";

export const loadPanelDelay: number = 200;

export const routerRoutes: Routes = {
   default: "/",
   dashboard: "/dashboard",
   report: "/report",
   location: "/location",
   client: "/client",
   device: "/device",
   role: "/role",
   rolePermission: "/rolepermission",
   user: "/user",
   signIn: "/signin",
   signOut: "/signout",
   anonymous: ["/signin"],
};

export const toastDisplayTime: number = 3_000;
