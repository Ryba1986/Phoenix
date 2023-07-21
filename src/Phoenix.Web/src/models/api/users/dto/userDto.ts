import { MetricDtoBase } from "../../base/dto/metricDtoBase";

export interface UserDto extends MetricDtoBase {
   name: string;
   email: string;
   roleId: number;
}
