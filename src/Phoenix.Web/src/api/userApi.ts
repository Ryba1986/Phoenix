import { getAsync, postAsync, postTokenAsync } from "../helpers/requestHelper";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { CreateUserCommand } from "../models/api/users/commands/createUserCommand";
import { UpdateUserCommand } from "../models/api/users/commands/updateUserCommand";
import { UpdateUserPasswordCommand } from "../models/api/users/commands/updateUserPasswordCommand";
import { UserDto } from "../models/api/users/dto/userDto";
import { UserHistoryDto } from "../models/api/users/dto/userHistoryDto";
import { GetUserHistoryQuery } from "../models/api/users/queries/getUserHistoryQuery";
import { GetUserTokenQuery } from "../models/api/users/queries/getUserTokenQuery";
import { Result } from "../models/requests/result";
import { TokenResult } from "../models/requests/tokenResult";
import { authStore } from "../stores/authStore";

const _authStore = authStore();

export function getUsersAsync(): Promise<Array<UserDto>> {
   return getAsync<Array<UserDto>>("user/getUsers");
}

export function getUserHistoryAsync(request: GetUserHistoryQuery): Promise<Array<UserHistoryDto>> {
   return getAsync<Array<UserHistoryDto>>("user/getUserHistory", request);
}

export function getUserDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("user/getUserDictionary");
}

export async function getUserTokenAsync(request: GetUserTokenQuery): Promise<void> {
   const result: TokenResult = await postTokenAsync("user/getUserToken", request);

   if (result.value) {
      _authStore.setToken(result.value);
      // TODO: add route to default
   } else {
      _authStore.removeToken();
   }
}

export async function getUserTokenRefreshAsync(): Promise<void> {
   const result: TokenResult = await postTokenAsync("user/getUserTokenRefresh");

   if (result.value) {
      _authStore.setToken(result.value);
   } else {
      _authStore.removeToken();
      // TODO: add route to default
   }
}

export function createUserAsync(command: CreateUserCommand): Promise<Result> {
   return postAsync("user/createUser", command);
}

export function updateUserAsync(command: UpdateUserCommand): Promise<Result> {
   return postAsync("user/updateUser", command);
}

export function updateUserPasswordAsync(command: UpdateUserPasswordCommand): Promise<Result> {
   return postAsync("user/updateUserPassword", command);
}
