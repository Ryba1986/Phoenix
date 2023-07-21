import { PlcDtoBase } from "../../../base/dto/plcDtoBase";

export interface ClimatixDto extends PlcDtoBase {
   outsideTemp: number;
   chHighInletPresure: number;
   chHighOutletPresure: number;
   alarm: boolean;
   ch1LowInletTemp: number;
   ch1LowOutletTemp: number;
   ch1LowOutletPresure: number;
   ch1HeatCurveTemp: number;
   ch1PumpAlarm: boolean;
   ch1PumpStatus: boolean;
   ch1ValvePosition: number;
   ch1Status: boolean;
   ch2LowInletTemp: number;
   ch2LowOutletTemp: number;
   ch2LowOutletPresure: number;
   ch2HeatCurveTemp: number;
   ch2PumpAlarm: boolean;
   ch2PumpStatus: boolean;
   ch2ValvePosition: number;
   ch2Status: boolean;
   dhwTemp: number;
   dhwTempSet: number;
   dhwPumpAlarm: boolean;
   dhwPumpStatus: boolean;
   dhwValvePosition: number;
   dhwStatus: boolean;
}
