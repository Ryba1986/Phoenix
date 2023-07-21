import { CreateCommandBase } from "../../base/commands/createCommandBase";

export interface CreateRolePermissionCommand extends CreateCommandBase {
   roleId: number;
   permission: number;
   accessLevel: number;
}
