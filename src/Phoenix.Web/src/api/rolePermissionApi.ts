import { ApiBase } from "./base/apiBase";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { CreateRolePermissionCommand } from "../models/api/roles/commands/createRolePermissionCommand";
import { UpdateRolePermissionCommand } from "../models/api/roles/commands/updateRolePermissionCommand";
import { RolePermissionDto } from "../models/api/roles/dto/rolePermissionDto";
import { GetRolePermissionsQuery } from "../models/api/roles/queries/getRolePermissionsQuery";
import { Result } from "../models/requests/result";

export class RolePermissionApi extends ApiBase {
   constructor() {
      super();
   }

   public getRolePermissionsAsync(request: GetRolePermissionsQuery): Promise<Array<RolePermissionDto>> {
      return this._requestHelper.getAsync<Array<RolePermissionDto>>("rolePermission/getRolePermissions", request);
   }

   public getAccessLevelDictionaryAsync(): Promise<Array<DictionaryItem>> {
      return this._requestHelper.getAsync<Array<DictionaryItem>>("rolePermission/getAccessLevelDictionary");
   }

   public getPermissionDictionaryAsync(): Promise<Array<DictionaryItem>> {
      return this._requestHelper.getAsync<Array<DictionaryItem>>("rolePermission/getPermissionDictionary");
   }

   public createRolePermissionAsync(command: CreateRolePermissionCommand): Promise<Result> {
      return this._requestHelper.postAsync("rolePermission/createRolePermission", command);
   }

   public updateRolePermissionAsync(command: UpdateRolePermissionCommand): Promise<Result> {
      return this._requestHelper.postAsync("rolePermission/updateRolePermission", command);
   }
}
