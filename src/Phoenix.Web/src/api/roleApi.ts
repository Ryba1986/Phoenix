import { ApiBase } from "./base/apiBase";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { CreateRoleCommand } from "../models/api/roles/commands/createRoleCommand";
import { UpdateRoleCommand } from "../models/api/roles/commands/updateRoleCommand";
import { RoleDto } from "../models/api/roles/dto/roleDto";
import { RoleHistoryDto } from "../models/api/roles/dto/roleHistoryDto";
import { GetRoleHistoryQuery } from "../models/api/roles/queries/getRoleHistoryQuery";
import { Result } from "../models/requests/result";

export class RoleApi extends ApiBase {
   constructor() {
      super();
   }

   public getRolesAsync(): Promise<Array<RoleDto>> {
      return this._requestHelper.getAsync<Array<RoleDto>>("role/getRoles");
   }

   public getRoleHistoryAsync(request: GetRoleHistoryQuery): Promise<Array<RoleHistoryDto>> {
      return this._requestHelper.getAsync<Array<RoleHistoryDto>>("role/getRoleHistory", request);
   }

   public getRoleDictionaryAsync(): Promise<Array<DictionaryItem>> {
      return this._requestHelper.getAsync<Array<DictionaryItem>>("role/getRoleDictionary");
   }

   public createRoleAsync(command: CreateRoleCommand): Promise<Result> {
      return this._requestHelper.postAsync("role/createRole", command);
   }

   public updateRoleAsync(command: UpdateRoleCommand): Promise<Result> {
      return this._requestHelper.postAsync("role/updateRole", command);
   }
}
