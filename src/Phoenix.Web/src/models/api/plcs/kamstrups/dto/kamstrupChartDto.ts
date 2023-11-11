import { PlcChartDtoBase } from '../../../base/dto/plcChartDtoBase';

export interface KamstrupChartDto extends PlcChartDtoBase {
   inletTemp: number;
   outletTemp: number;
   power: number;
   volume: number;
}
