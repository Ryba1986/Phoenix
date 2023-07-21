import { CreateCommandBase } from "../../base/commands/createCommandBase";

export interface CreateClientCommand extends CreateCommandBase {
   locationId: number;
   macAddress: string;
}
