import { MetricDtoBase } from "../../base/dto/metricDtoBase";

export interface DeviceDto extends MetricDtoBase {
   locationId: number;
   name: string;
   deviceType: number;
   plcType: number;
   modbusId: number;
   boundRate: number;
   dataBits: number;
   parity: number;
   stopBits: number;
   serialNumber: string;
   includeReport: boolean;
   reportSequence: number;
}
