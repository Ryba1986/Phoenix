import { UpdateCommandBase } from "../../base/commands/updateCommandBase";

export interface UpdateUserCommand extends UpdateCommandBase {
   name: string;
   email: string;
   roleId: number;
}
