import { CreateCommandBase } from "../../base/commands/createCommandBase";

export interface CreateRoleCommand extends CreateCommandBase {
   name: string;
   isAdmin: boolean;
}
