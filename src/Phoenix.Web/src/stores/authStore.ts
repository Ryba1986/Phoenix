import { JwtPayload, jwtDecode } from 'jwt-decode';
import { defineStore } from 'pinia';
import { apiTokenEmptyValue, apiTokenName, routerRoutes } from '../config';
import { AuthState } from '../models/stores/authState';
import router from '../router';

export const authStore = defineStore('authStore', {
   state: (): AuthState => {
      return {
         token: initToken(),
      };
   },
   getters: {
      isLogged: (state): boolean => state.token != apiTokenEmptyValue,
   },
   actions: {
      setToken(value: string): void {
         const initIsLogged: boolean = this.isLogged;

         localStorage.setItem(apiTokenName, value);
         this.token = value;

         if (!this.isLogged) {
            router.push(routerRoutes.signIn);
            return;
         }
         if (!initIsLogged && this.isLogged) {
            router.push(routerRoutes.default);
         }
      },
   },
});

function initToken(): string {
   const token: string = localStorage.getItem(apiTokenName) ?? apiTokenEmptyValue;
   if (!token) {
      return token;
   }

   try {
      const decoded: JwtPayload = jwtDecode<JwtPayload>(token);
      if (!decoded.exp || Date.now() > decoded.exp * 1000) {
         return apiTokenEmptyValue;
      }

      return token;
   } catch {
      return apiTokenEmptyValue;
   }
}
