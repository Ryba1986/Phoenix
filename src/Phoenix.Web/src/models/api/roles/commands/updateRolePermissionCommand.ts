import { UpdateCommandBase } from '../../base/commands/updateCommandBase';

export interface UpdateRolePermissionCommand extends UpdateCommandBase {
   accessLevel: number;
}
