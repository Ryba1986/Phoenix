import { CreateCommandBase } from '../../base/commands/createCommandBase';

export interface CreateUserCommand extends CreateCommandBase {
   roleId: number;
   name: string;
   email: string;
}
