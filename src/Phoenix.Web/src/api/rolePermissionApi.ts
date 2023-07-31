import { getAsync, postAsync } from "../helpers/requestHelper";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { CreateRolePermissionCommand } from "../models/api/roles/commands/createRolePermissionCommand";
import { UpdateRolePermissionCommand } from "../models/api/roles/commands/updateRolePermissionCommand";
import { RolePermissionDto } from "../models/api/roles/dto/rolePermissionDto";
import { Result } from "../models/requests/result";

export function getRolePermissionsAsync(): Promise<Array<RolePermissionDto>> {
   return getAsync<Array<RolePermissionDto>>("rolePermission/getRolePermissions");
}

export function getAccessLevelDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("rolePermission/getAccessLevelDictionary");
}

export function getPermissionDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("rolePermission/getPermissionDictionary");
}

export function createRolePermissionAsync(command: CreateRolePermissionCommand): Promise<Result> {
   return postAsync("rolePermission/createRolePermission", command);
}

export function updateRolePermissionAsync(command: UpdateRolePermissionCommand): Promise<Result> {
   return postAsync("rolePermission/updateRolePermission", command);
}
