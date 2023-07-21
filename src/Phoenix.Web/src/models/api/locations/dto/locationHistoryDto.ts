import { HistoryDtoBase } from "../../base/dto/historyDtoBase";

export interface LocationHistoryDto extends HistoryDtoBase {
   name: string;
   includeReport: boolean;
}
