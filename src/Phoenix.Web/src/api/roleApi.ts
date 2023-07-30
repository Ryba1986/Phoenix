import { getAsync, postAsync } from "../helpers/requestHelper";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { CreateRoleCommand } from "../models/api/roles/commands/createRoleCommand";
import { UpdateRoleCommand } from "../models/api/roles/commands/updateRoleCommand";
import { RoleDto } from "../models/api/roles/dto/roleDto";
import { RoleHistoryDto } from "../models/api/roles/dto/roleHistoryDto";
import { GetRoleHistoryQuery } from "../models/api/roles/queries/getRoleHistoryQuery";
import { Result } from "../models/requests/result";

export function getRolesAsync(): Promise<Array<RoleDto>> {
   return getAsync<Array<RoleDto>>("role/getRoles");
}

export function getRoleHistoryAsync(request: GetRoleHistoryQuery): Promise<Array<RoleHistoryDto>> {
   return getAsync<Array<RoleHistoryDto>>("role/getRoleHistory", request);
}

export function getRoleDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("role/getRoleDictionary");
}

export function createRoleAsync(command: CreateRoleCommand): Promise<Result> {
   return postAsync("role/createRole", command);
}

export function updateRoleAsync(command: UpdateRoleCommand): Promise<Result> {
   return postAsync("role/updateRole", command);
}
