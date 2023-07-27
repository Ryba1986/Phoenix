import { Routes } from "../models/routers/routes";

export const apiRequestContentType: string = "application/json";
export const apiTokenName: string = "ApiToken";
export const apiTokenEmptyValue: string = "";
export const apiTokenRefreshInterval: number = 60_000;
export const apiUrlBase: string = "/apiweb/";

export const routerRoutes: Routes = {
   default: "/",
   dashboard: "/dashboard",
   report: "/report",
   location: "/location",
   client: "/client",
   device: "/device",
   role: "/role",
   user: "/user",
   signIn: "/signin",
   signOut: "/signout",
   anonymous: ["/signin"],
};
