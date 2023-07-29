import { ApiBase } from "./base/apiBase";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { GetReportQuery } from "../models/api/reports/queries/getReportQuery";
import { FileResult } from "../models/requests/fileResult";

export class ReportApi extends ApiBase {
   constructor() {
      super();
   }

   public getReportTypeDictionaryAsync(): Promise<Array<DictionaryItem>> {
      return this._requestHelper.getAsync<Array<DictionaryItem>>("report/getReportTypeDictionary");
   }

   public getReportAsync(request: GetReportQuery): Promise<FileResult> {
      return this._requestHelper.getFileAsync("report/getReport", request);
   }
}
