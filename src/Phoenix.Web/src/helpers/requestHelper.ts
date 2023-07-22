import { useI18n } from "vue-i18n";
import { authStore } from "../stores/authStore";
import { apiRequestContentType, apiUrlBase } from "../config";
import { Result } from "../models/requests/result";
import { CommandBase } from "../models/api/base/commands/commandBase";
import { TokenResult } from "../models/requests/tokenResult";
import { GetUserTokenQuery } from "../models/api/users/queries/getUserTokenQuery";

const _authStore = authStore();
const { t } = useI18n();

function getHeders(): HeadersInit {
   return {
      Authorization: `Bearer ${_authStore.token}`,
      "Content-Type": apiRequestContentType,
   };
}

function handleErrorAsync<T>(statusCode: number): Promise<T> {
   if (statusCode == 401) {
      _authStore.removeToken();
      // TODO: add route to default

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
      return Promise.reject<TokenResult>(t("requests.userNotFound"));
   }

   return Promise.resolve<TokenResult>(result);
}
