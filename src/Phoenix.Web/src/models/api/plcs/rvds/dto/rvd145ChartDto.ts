import { PlcChartDtoBase } from '../../../base/dto/plcChartDtoBase';

export interface Rvd145ChartDto extends PlcChartDtoBase {
   outsideTemp: number;
   chHighInletPresure: number;
   ch1HighOutletTemp: number;
   ch1LowInletTemp: number;
   ch1LowOutletPresure: number;
   ch1HeatCurveTemp: number;
   dhwTemp: number;
   dhwTempSet: number;
}
