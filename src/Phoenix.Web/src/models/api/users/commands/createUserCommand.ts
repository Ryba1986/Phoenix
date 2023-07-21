import { CreateCommandBase } from "../../base/commands/createCommandBase";

export interface CreateUserCommand extends CreateCommandBase {
   name: string;
   email: string;
   roleId: number;
}
