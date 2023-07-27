import jwt_decode, { JwtPayload } from "jwt-decode";
import { defineStore } from "pinia";
import { apiTokenEmptyValue, apiTokenName, routerRoutes } from "../config";
import { AuthState } from "../models/stores/authState";
import router from "../router";

function initToken(): string {
   const token: string = localStorage.getItem(apiTokenName) ?? apiTokenEmptyValue;
   if (!token) {
      return apiTokenEmptyValue;
   }

   try {
      const decoded: JwtPayload = jwt_decode<JwtPayload>(token);
      if (!decoded.exp || Date.now() > decoded.exp * 1000) {
         return apiTokenEmptyValue;
      }

      return token;
   } catch {
      return apiTokenEmptyValue;
   }
}

export const authStore = defineStore("authStore", {
   state: (): AuthState => {
      return {
         token: initToken(),
      };
   },
   getters: {
      isLogged: (state): boolean => state.token.length > 0,
   },
   actions: {
      removeToken(): void {
         localStorage.removeItem(apiTokenName);
         this.token = apiTokenEmptyValue;
         router.push(routerRoutes.signIn);
      },
      refreshToken(value: string): void {
         localStorage.setItem(apiTokenName, value);
         this.token = value;
      },
      setToken(value: string): void {
         localStorage.setItem(apiTokenName, value);
         this.token = value;
         router.push(routerRoutes.default);
      },
   },
});
