import { DtoBase } from './dtoBase';

export interface MetricDtoBase extends DtoBase {
   isActive: boolean;
   version: number;
}
