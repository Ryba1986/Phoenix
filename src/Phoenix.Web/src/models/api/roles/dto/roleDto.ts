import { MetricDtoBase } from '../../base/dto/metricDtoBase';

export interface RoleDto extends MetricDtoBase {
   name: string;
   isAdmin: boolean;
}
