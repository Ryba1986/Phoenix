import { QueryBase } from '../../base/queries/queryBase';

export interface GetDevicesByLocationQuery extends QueryBase {
   locationId: number;
}
