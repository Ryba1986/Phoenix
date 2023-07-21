import { PlcChartDtoBase } from "../../../base/dto/plcChartDtoBase";

export interface ClimatixChartDto extends PlcChartDtoBase {
   outsideTemp: number;
   chHighInletPresure: number;
   chHighOutletPresure: number;
   ch1LowInletTemp: number;
   ch1LowOutletTemp: number;
   ch1LowOutletPresure: number;
   ch1HeatCurveTemp: number;
   ch2LowInletTemp: number;
   ch2LowOutletTemp: number;
   ch2LowOutletPresure: number;
   ch2HeatCurveTemp: number;
   dhwTemp: number;
   dhwTempSet: number;
}
