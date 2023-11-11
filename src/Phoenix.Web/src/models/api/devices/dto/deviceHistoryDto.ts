import { HistoryDtoBase } from '../../base/dto/historyDtoBase';

export interface DeviceHistoryDto extends HistoryDtoBase {
   name: string;
   locationName: string;
   plcType: string;
   modbusId: string;
   boundRate: number;
   dataBits: number;
   parity: number;
   stopBits: number;
   reportSequence: string;
   includeReport: boolean;
}
