import { MetricDtoBase } from '../../base/dto/metricDtoBase';

export interface UserDto extends MetricDtoBase {
   roleId: number;
   name: string;
   email: string;
}
