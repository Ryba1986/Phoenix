import { DtoBase } from "./dtoBase";

export interface HistoryDtoBase extends DtoBase {
   isActive: boolean;
   createdByName: string;
   createDate: Date;
}
