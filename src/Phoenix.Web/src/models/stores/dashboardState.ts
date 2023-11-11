import { DictionaryItem } from '../api/base/dto/dictionaryItem';

export interface DashboardState {
   locationId: number;
   locations: Array<DictionaryItem>;
}
