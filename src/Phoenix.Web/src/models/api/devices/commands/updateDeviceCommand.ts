import { UpdateCommandBase } from '../../base/commands/updateCommandBase';

export interface UpdateDeviceCommand extends UpdateCommandBase {
   locationId: number;
   name: string;
   plcType: number;
   modbusId: number;
   boundRate: number;
   dataBits: number;
   parity: number;
   stopBits: number;
   sequence: number;
   includeReport: boolean;
}
