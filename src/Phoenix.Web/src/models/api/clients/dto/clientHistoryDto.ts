import { HistoryDtoBase } from "../../base/dto/historyDtoBase";

export interface ClientHistoryDto extends HistoryDtoBase {
   locationName: string;
   macAddress: string;
}
