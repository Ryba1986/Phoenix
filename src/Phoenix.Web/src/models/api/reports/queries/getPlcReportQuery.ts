import { QueryBase } from '../../base/queries/queryBase';

export interface GetPlcReportQuery extends QueryBase {
   date: string;
   type: number;
}
