import { ClimatixChartDto } from "../models/api/plcs/climatixs/dto/climatixChartDto";
import { ClimatixDto } from "../models/api/plcs/climatixs/dto/climatixDto";
import { GetClimatixChartQuery } from "../models/api/plcs/climatixs/queries/getClimatixChartQuery";
import { GetClimatixLastQuery } from "../models/api/plcs/climatixs/queries/getClimatixLastQuery";
import { ApiBase } from "./base/apiBase";

export class ClimatixApi extends ApiBase {
   constructor() {
      super();
   }

   public getClimatixChartAsync(request: GetClimatixChartQuery): Promise<Array<ClimatixChartDto>> {
      return this._requestHelper.getAsync<Array<ClimatixChartDto>>("climatix/getClimatixChart", request);
   }

   public getClimatixLastAsync(request: GetClimatixLastQuery): Promise<ClimatixDto> {
      return this._requestHelper.getAsync<ClimatixDto>("kamstrup/getClimatixLast", request);
   }
}
