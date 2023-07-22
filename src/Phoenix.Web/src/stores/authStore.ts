import { defineStore } from "pinia";
import { apiTokenEmptyValue, apiTokenName } from "../config";
import { AuthState } from "../models/stores/authState";

export const authStore = defineStore("authStore", {
   state: (): AuthState => {
      return {
         token: localStorage.getItem(apiTokenName) ?? apiTokenEmptyValue,
      };
   },
   getters: {
      isLogged: (state): boolean => state.token.length > 0,
   },
   actions: {
      removeToken(): void {
         localStorage.removeItem(apiTokenName);
         this.token = apiTokenEmptyValue;
      },
      setToken(value: string): void {
         localStorage.setItem(apiTokenName, value);
         this.token = value;
      },
   },
});
