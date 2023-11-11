import { QueryBase } from './queryBase';

export interface GetPlcChartQueryBase extends QueryBase {
   date: string;
   deviceId: number;
}
