import { ApiBase } from "./base/apiBase";
import { KamstrupChartDto } from "../models/api/plcs/meters/dto/kamstrupChartDto";
import { KamstrupDto } from "../models/api/plcs/meters/dto/kamstrupDto";
import { GetKamstrupChartQuery } from "../models/api/plcs/meters/queries/getKamstrupChartQuery";
import { GetKamstrupLastQuery } from "../models/api/plcs/meters/queries/getKamstrupLastQuery";

export class KamstrupApi extends ApiBase {
   constructor() {
      super();
   }

   public getKamstrupChartAsync(request: GetKamstrupChartQuery): Promise<Array<KamstrupChartDto>> {
      return this._requestHelper.getAsync<Array<KamstrupChartDto>>("kamstrup/getKamstrupChart", request);
   }

   public getKamstrupLastAsync(request: GetKamstrupLastQuery): Promise<KamstrupDto> {
      return this._requestHelper.getAsync<KamstrupDto>("kamstrup/getKamstrupLast", request);
   }
}
