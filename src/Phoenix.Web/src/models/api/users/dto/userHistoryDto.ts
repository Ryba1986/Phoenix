import { HistoryDtoBase } from "../../base/dto/historyDtoBase";

export interface UserHistoryDto extends HistoryDtoBase {
   name: string;
   email: string;
   roleName: string;
}
