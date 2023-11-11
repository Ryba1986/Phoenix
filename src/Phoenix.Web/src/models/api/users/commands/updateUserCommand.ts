import { UpdateCommandBase } from '../../base/commands/updateCommandBase';

export interface UpdateUserCommand extends UpdateCommandBase {
   roleId: number;
   name: string;
   email: string;
}
