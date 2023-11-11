import { getAsync, getFileAsync } from '../helpers/requestHelper';
import { DictionaryItem } from '../models/api/base/dto/dictionaryItem';
import { GetPlcReportQuery } from '../models/api/reports/queries/getPlcReportQuery';
import { FileResult } from '../models/requests/fileResult';

export function getPlcReportTypeDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>('report/getPlcReportTypeDictionary');
}

export function getPlcReportAsync(request: GetPlcReportQuery): Promise<FileResult> {
   return getFileAsync('report/getPlcReport', request);
}
