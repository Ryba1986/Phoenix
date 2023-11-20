import { QueryBase } from './queryBase';

export interface GetPlcChartQueryBase extends QueryBase {
   deviceId: number;
   date: string;
}
