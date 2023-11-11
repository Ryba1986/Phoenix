import { CreateCommandBase } from '../../base/commands/createCommandBase';

export interface CreateDeviceCommand extends CreateCommandBase {
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
