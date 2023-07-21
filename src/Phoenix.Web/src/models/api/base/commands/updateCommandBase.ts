import { CommandBase } from "./commandBase";

export interface UpdateCommandBase extends CommandBase {
   id: number;
   isActive: boolean;
   version: string;
}
