import { MetricDtoBase } from '../../base/dto/metricDtoBase';
import { PlcType } from '../enums/plcType';

export interface DeviceDto extends MetricDtoBase {
   locationId: number;
   name: string;
   plcType: PlcType;
   modbusId: number;
   boundRate: number;
   dataBits: number;
   parity: number;
   stopBits: number;
   serialNumber: string;
   sequence: number;
   includeReport: boolean;
}
