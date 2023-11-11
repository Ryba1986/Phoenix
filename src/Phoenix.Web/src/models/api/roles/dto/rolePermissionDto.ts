import { MetricDtoBase } from '../../base/dto/metricDtoBase';

export interface RolePermissionDto extends MetricDtoBase {
   roleId: number;
   permission: number;
   accessLevel: number;
}
