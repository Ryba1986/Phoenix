import { UpdateCommandBase } from "../../base/commands/updateCommandBase";

export interface UpdateDeviceCommand extends UpdateCommandBase {
   locationId: number;
   name: string;
   deviceType: number;
   plcType: number;
   modbusId: number;
   boundRate: number;
   dataBits: number;
   parity: number;
   stopBits: number;
   includeReport: boolean;
   reportSequence: number;
}
