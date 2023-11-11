import { QueryBase } from '../../base/queries/queryBase';

export interface GetClientHistoryQuery extends QueryBase {
   clientId: number;
}
