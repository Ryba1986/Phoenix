import { HistoryDtoBase } from "../../base/dto/historyDtoBase";

export interface RoleHistoryDto extends HistoryDtoBase {
   name: string;
   isAdmin: boolean;
}
