import { QueryBase } from '../../base/queries/queryBase';

export interface GetUserHistoryQuery extends QueryBase {
   userId: number;
}
