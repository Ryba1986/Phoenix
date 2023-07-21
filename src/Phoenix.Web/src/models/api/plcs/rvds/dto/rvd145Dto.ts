import { PlcDtoBase } from "../../../base/dto/plcDtoBase";

export interface Rvd145Dto extends PlcDtoBase {
   outsideTemp: number;
   chHighInletPresure: number;
   alarm: number;
   ch1HighOutletTemp: number;
   ch1LowInletTemp: number;
   ch1LowOutletPresure: number;
   ch1HeatCurveTemp: number;
   ch1PumpStatus: boolean;
   ch1Status: boolean;
   dhwTemp: number;
   dhwTempSet: number;
   dhwCirculationTemp: number;
   dhwPumpStatus: boolean;
   dhwStatus: boolean;
}
