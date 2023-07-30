import { useI18n } from "vue-i18n";
import { apiRequestContentType, apiUrlBase } from "../config";
import { CommandBase } from "../models/api/base/commands/commandBase";
import { GetUserTokenQuery } from "../models/api/users/queries/getUserTokenQuery";
import { FileResult } from "../models/requests/fileResult";
import { Result } from "../models/requests/result";
import { TokenResult } from "../models/requests/tokenResult";
import { authStore } from "../stores/authStore";

function getHeders(): HeadersInit {
   return {
      Authorization: `Bearer ${authStore().token}`,
      "Content-Type": apiRequestContentType,
   };
}

function handleErrorAsync<T>(statusCode: number): Promise<T> {
   const { t } = useI18n();

   if (statusCode == 401) {
      authStore().removeToken();

      return Promise.reject<T>(t("requests.unauthorized"));
   }

   if (statusCode == 403) {
      return Promise.reject<T>(t("requests.forbidden"));
   }

   return Promise.reject<T>(t("requests.default"));
}

function toQueryString(url: string, request: any): string {
   const queryString: string = Object.keys(request)
      .map((x: string) => `${encodeURIComponent(x)}=${encodeURIComponent(request[x])}`)
      .join("&");

   return `${url}?${queryString}`;
}

export async function getAsync<T>(url: string, request?: any): Promise<T> {
   if (request) {
      url = toQueryString(url, request);
   }

   const response: Response = await fetch(`${apiUrlBase}${url}`, {
      method: "GET",
      headers: getHeders(),
   });

   if (!response.ok) {
      return handleErrorAsync<T>(response.status);
   }

   return Promise.resolve<T>(await response.json());
}

export async function getFileAsync(url: string, request?: any): Promise<FileResult> {
   if (request) {
      url = toQueryString(url, request);
   }

   const response: Response = await fetch(`${apiUrlBase}${url}`, {
      method: "GET",
      headers: getHeders(),
   });

   if (!response.ok) {
      return handleErrorAsync<FileResult>(response.status);
   }

   const fileName: string = response.headers.get("content-disposition")?.split("filename=")[1] ?? "";
   if (!fileName) {
      return Promise.reject(useI18n().t("requests.fileNameNotExists"));
   }

   return {
      name: fileName.substring(0, fileName.indexOf(";")).trim(),
      data: await response.blob(),
   };
}

export async function postAsync(url: string, data?: CommandBase): Promise<Result> {
   const requestOptions: RequestInit = {
      method: "POST",
      headers: getHeders(),
   };

   if (data) {
      requestOptions.body = JSON.stringify(data);
   }

   const response: Response = await fetch(`${apiUrlBase}${url}`, requestOptions);
   if (!response.ok) {
      return handleErrorAsync<Result>(response.status);
   }

   const result: Result = await response.json();
   if (!result.isSuccess) {
      return Promise.reject<Result>(result.message);
   }

   return Promise.resolve<Result>(result);
}

export async function postTokenAsync(url: string, data?: GetUserTokenQuery): Promise<TokenResult> {
   const requestOptions: RequestInit = {
      method: "POST",
      headers: getHeders(),
   };

   if (data) {
      requestOptions.body = JSON.stringify(data);
   }

   const response: Response = await fetch(`${apiUrlBase}${url}`, requestOptions);
   if (!response.ok) {
      return handleErrorAsync<TokenResult>(response.status);
   }

   const result: TokenResult = await response.json();
   if (!result.value) {
      return Promise.reject<TokenResult>(useI18n().t("requests.userNotFound"));
   }

   return Promise.resolve<TokenResult>(result);
}
