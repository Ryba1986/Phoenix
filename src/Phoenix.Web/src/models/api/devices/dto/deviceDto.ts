import { MetricDtoBase } from '../../base/dto/metricDtoBase';

export interface DeviceDto extends MetricDtoBase {
   locationId: number;
   name: string;
   plcType: number;
   modbusId: number;
   boundRate: number;
   dataBits: number;
   parity: number;
   stopBits: number;
   serialNumber: string;
   reportSequence: number;
   includeReport: boolean;
}
