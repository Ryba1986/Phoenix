import { PlcDtoBase } from "../../../base/dto/plcDtoBase";

export interface KamstrupDto extends PlcDtoBase {
   inletTemp: number;
   outletTemp: number;
   power: number;
   volume: number;
   volumeSummary: number;
   energySummary: number;
   hourCount: number;
   errorCode: number;
}
