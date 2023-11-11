import { MetricDtoBase } from '../../base/dto/metricDtoBase';

export interface LocationDto extends MetricDtoBase {
   name: string;
   includeReport: boolean;
}
