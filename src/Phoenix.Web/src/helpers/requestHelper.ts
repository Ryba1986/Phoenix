import { apiRequestContentType, apiTokenEmptyValue, apiUrlBase } from '../config';
import { i18n } from '../languages';
import { CommandBase } from '../models/api/base/commands/commandBase';
import { DictionaryItem } from '../models/api/base/dto/dictionaryItem';
import { DtoBase } from '../models/api/base/dto/dtoBase';
import { PlcChartDtoBase } from '../models/api/base/dto/plcChartDtoBase';
import { PlcDtoBase } from '../models/api/base/dto/plcDtoBase';
import { QueryBase } from '../models/api/base/queries/queryBase';
import { GetUserTokenQuery } from '../models/api/users/queries/getUserTokenQuery';
import { FileResult } from '../models/requests/fileResult';
import { Result } from '../models/requests/result';
import { TokenResult } from '../models/requests/tokenResult';
import { authStore } from '../stores/authStore';

const { locale, t } = i18n.global;

export async function getAsync<T extends DictionaryItem | DtoBase | PlcDtoBase | PlcChartDtoBase | Array<DictionaryItem> | Array<DtoBase> | Array<PlcDtoBase> | Array<PlcChartDtoBase>>(
   url: string,
   request?: QueryBase
): Promise<T> {
   if (request) {
      url = toQueryString(url, request);
   }

   const response: Response = await fetch(`${apiUrlBase}${url}`, {
      method: 'GET',
      headers: getHeders(),
   });

   if (!response.ok) {
      return handleErrorAsync<T>(response.status);
   }

   return Promise.resolve<T>(await response.json());
}

export async function getFileAsync(url: string, request?: QueryBase): Promise<FileResult> {
   if (request) {
      url = toQueryString(url, request);
   }

   const response: Response = await fetch(`${apiUrlBase}${url}`, {
      method: 'GET',
      headers: getHeders(),
   });

   if (!response.ok) {
      return handleErrorAsync<FileResult>(response.status);
   }

   const fileName: string = response.headers.get('content-disposition')?.split('filename=')[1] ?? '';
   if (!fileName) {
      return Promise.reject(t('requests.fileNameNotExists'));
   }

   return {
      name: fileName.substring(0, fileName.indexOf(';')).trim(),
      data: await response.blob(),
   };
}

export async function postAsync(url: string, request: CommandBase): Promise<Result> {
   const requestOptions: RequestInit = {
      method: 'POST',
      headers: getHeders(),
   };

   if (request) {
      requestOptions.body = JSON.stringify(request);
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

export async function postTokenAsync(url: string, request?: GetUserTokenQuery): Promise<TokenResult> {
   const requestOptions: RequestInit = {
      method: 'POST',
      headers: getHeders(),
   };

   if (request) {
      requestOptions.body = JSON.stringify(request);
   }

   const response: Response = await fetch(`${apiUrlBase}${url}`, requestOptions);
   if (!response.ok) {
      return handleErrorAsync<TokenResult>(response.status);
   }

   return Promise.resolve<TokenResult>(await response.json());
}

function getHeders(): HeadersInit {
   return {
      'Accept-Language': locale.value,
      Authorization: `Bearer ${authStore().token}`,
      'Content-Type': apiRequestContentType,
   };
}

function handleErrorAsync<T>(statusCode: number): Promise<T> {
   if (statusCode == 401) {
      authStore().setToken(apiTokenEmptyValue);
      return Promise.reject<T>(t('requests.unauthorized'));
   }

   if (statusCode == 403) {
      return Promise.reject<T>(t('requests.forbidden'));
   }

   return Promise.reject<T>(t('requests.default'));
}

function toQueryString(url: string, request: any): string {
   const queryString: string = Object.keys(request)
      .map((x: string) => `${encodeURIComponent(x)}=${encodeURIComponent(request[x])}`)
      .join('&');

   return `${url}?${queryString}`;
}
