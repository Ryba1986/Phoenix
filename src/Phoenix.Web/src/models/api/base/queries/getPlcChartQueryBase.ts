import { QueryBase } from './queryBase';

export interface GetPlcChartQueryBase extends QueryBase {
   startDate: string;
   deviceId: number;
}
