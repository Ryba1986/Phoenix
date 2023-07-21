import { UpdateCommandBase } from "../../base/commands/updateCommandBase";

export interface UpdateLocationCommand extends UpdateCommandBase {
   name: string;
   includeReport: boolean;
}
