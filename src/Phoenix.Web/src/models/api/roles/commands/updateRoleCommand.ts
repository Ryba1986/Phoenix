import { UpdateCommandBase } from '../../base/commands/updateCommandBase';

export interface UpdateRoleCommand extends UpdateCommandBase {
   name: string;
   isAdmin: boolean;
}
