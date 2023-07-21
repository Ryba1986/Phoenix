import { HistoryDtoBase } from "../../base/dto/historyDtoBase";

export interface DeviceHistoryDto extends HistoryDtoBase {
   name: string;
   locationName: string;
   deviceType: string;
   plcType: string;
   modbusId: string;
   boundRate: string;
   dataBits: string;
   parity: string;
   stopBits: string;
   includeReport: boolean;
   reportSequence: string;
}
