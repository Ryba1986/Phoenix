import { MetricDtoBase } from "../../base/dto/metricDtoBase";

export interface ClientDto extends MetricDtoBase {
   locationId: number;
   macAddress: string;
   hostname: string;
   clientVersion: string;
}
