import { ApiBase } from "./base/apiBase";
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

export class UserApi extends ApiBase {
   private readonly _authStore;

   constructor() {
      super();
      this._authStore = authStore();
   }

   public getUsersAsync(): Promise<Array<UserDto>> {
      return this._requestHelper.getAsync<Array<UserDto>>("user/getUsers");
   }

   public getUserHistoryAsync(request: GetUserHistoryQuery): Promise<Array<UserHistoryDto>> {
      return this._requestHelper.getAsync<Array<UserHistoryDto>>("user/getUserHistory", request);
   }

   public getUserDictionaryAsync(): Promise<Array<DictionaryItem>> {
      return this._requestHelper.getAsync<Array<DictionaryItem>>("user/getUserDictionary");
   }

   public async getUserTokenAsync(request: GetUserTokenQuery): Promise<void> {
      const result: TokenResult = await this._requestHelper.postTokenAsync("user/getUserToken", request);

      if (result.value) {
         this._authStore.setToken(result.value);
         // TODO: add route to default
      } else {
         this._authStore.removeToken();
      }
   }

   public async getUserTokenRefreshAsync(): Promise<void> {
      const result: TokenResult = await this._requestHelper.postTokenAsync("user/getUserTokenRefresh");

      if (result.value) {
         this._authStore.setToken(result.value);
      } else {
         this._authStore.removeToken();
         // TODO: add route to default
      }
   }

   public createUserAsync(command: CreateUserCommand): Promise<Result> {
      return this._requestHelper.postAsync("user/createUser", command);
   }

   public updateUserAsync(command: UpdateUserCommand): Promise<Result> {
      return this._requestHelper.postAsync("user/updateUser", command);
   }

   public updateUserPasswordAsync(command: UpdateUserPasswordCommand): Promise<Result> {
      return this._requestHelper.postAsync("user/updateUserPassword", command);
   }
}
