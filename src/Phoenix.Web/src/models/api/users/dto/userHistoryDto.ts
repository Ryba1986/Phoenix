import { HistoryDtoBase } from '../../base/dto/historyDtoBase';

export interface UserHistoryDto extends HistoryDtoBase {
   roleName: string;
   name: string;
   email: string;
}
