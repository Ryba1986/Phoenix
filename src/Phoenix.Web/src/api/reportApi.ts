import { getAsync, getFileAsync } from "../helpers/requestHelper";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { GetReportQuery } from "../models/api/reports/queries/getReportQuery";
import { FileResult } from "../models/requests/fileResult";

export function getReportTypeDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("report/getReportTypeDictionary");
}

export function getReportAsync(request: GetReportQuery): Promise<FileResult> {
   return getFileAsync("report/getReport", request);
}
