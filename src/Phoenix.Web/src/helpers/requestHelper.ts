import { useI18n } from "vue-i18n";
import { apiRequestContentType, apiUrlBase, routerRoutes } from "../config";
import { CommandBase } from "../models/api/base/commands/commandBase";
import { GetUserTokenQuery } from "../models/api/users/queries/getUserTokenQuery";
import { FileResult } from "../models/requests/fileResult";
import { Result } from "../models/requests/result";
import { TokenResult } from "../models/requests/tokenResult";
import router from "../router";
import { authStore } from "../stores/authStore";

export class RequestHelper {
   private readonly _authStore;
   private readonly _translation;

   constructor() {
      this._authStore = authStore();
      this._translation = useI18n().t;
   }

   public async getAsync<T>(url: string, request?: any): Promise<T> {
      if (request) {
         url = this.toQueryString(url, request);
      }

      const response: Response = await fetch(`${apiUrlBase}${url}`, {
         method: "GET",
         headers: this.getHeders(),
      });

      if (!response.ok) {
         return this.handleErrorAsync<T>(response.status);
      }

      return Promise.resolve<T>(await response.json());
   }

   public getFileAsync = async (url: string, request?: any): Promise<FileResult> => {
      if (request) {
         url = this.toQueryString(url, request);
      }

      const response: Response = await fetch(`${apiUrlBase}${url}`, {
         method: "GET",
         headers: this.getHeders(),
      });

      if (!response.ok) {
         return this.handleErrorAsync<FileResult>(response.status);
      }

      const fileName: string = response.headers.get("content-disposition")?.split("filename=")[1] ?? "";
      if (!fileName) {
         return Promise.reject(this._translation("requests.fileNameNotExists"));
      }

      return {
         name: fileName.substring(0, fileName.indexOf(";")).trim(),
         data: await response.blob(),
      };
   };

   public async postAsync(url: string, data?: CommandBase): Promise<Result> {
      const requestOptions: RequestInit = {
         method: "POST",
         headers: this.getHeders(),
      };

      if (data) {
         requestOptions.body = JSON.stringify(data);
      }

      const response: Response = await fetch(`${apiUrlBase}${url}`, requestOptions);
      if (!response.ok) {
         return this.handleErrorAsync<Result>(response.status);
      }

      const result: Result = await response.json();
      if (!result.isSuccess) {
         return Promise.reject<Result>(result.message);
      }

      return Promise.resolve<Result>(result);
   }

   public async postTokenAsync(url: string, data?: GetUserTokenQuery): Promise<TokenResult> {
      const requestOptions: RequestInit = {
         method: "POST",
         headers: this.getHeders(),
      };

      if (data) {
         requestOptions.body = JSON.stringify(data);
      }

      const response: Response = await fetch(`${apiUrlBase}${url}`, requestOptions);
      if (!response.ok) {
         return this.handleErrorAsync<TokenResult>(response.status);
      }

      const result: TokenResult = await response.json();
      if (!result.value) {
         return Promise.reject<TokenResult>(this._translation("requests.userNotFound"));
      }

      return Promise.resolve<TokenResult>(result);
   }

   private getHeders(): HeadersInit {
      return {
         Authorization: `Bearer ${this._authStore.token}`,
         "Content-Type": apiRequestContentType,
      };
   }

   private handleErrorAsync<T>(statusCode: number): Promise<T> {
      if (statusCode == 401) {
         this._authStore.removeToken();
         router.push(routerRoutes.default);

         return Promise.reject<T>(this._translation("requests.unauthorized"));
      }

      if (statusCode == 403) {
         return Promise.reject<T>(this._translation("requests.forbidden"));
      }

      return Promise.reject<T>(this._translation("requests.default"));
   }

   private toQueryString(url: string, request: any): string {
      const queryString: string = Object.keys(request)
         .map((x: string) => `${encodeURIComponent(x)}=${encodeURIComponent(request[x])}`)
         .join("&");

      return `${url}?${queryString}`;
   }
}
