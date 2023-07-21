import { UpdateCommandBase } from "../../base/commands/updateCommandBase";

export interface UpdateClientCommand extends UpdateCommandBase {
   locationId: number;
   macAddress: string;
}
