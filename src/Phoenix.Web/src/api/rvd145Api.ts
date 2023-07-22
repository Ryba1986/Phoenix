import { Rvd145ChartDto } from "../models/api/plcs/rvds/dto/rvd145ChartDto";
import { Rvd145Dto } from "../models/api/plcs/rvds/dto/rvd145Dto";
import { GetRvd145ChartQuery } from "../models/api/plcs/rvds/queries/getRvd145ChartQuery";
import { GetRvd145LastQuery } from "../models/api/plcs/rvds/queries/getRvd145LastQuery";
import { ApiBase } from "./base/apiBase";

export class Rvd145Api extends ApiBase {
   constructor() {
      super();
   }

   public getRvd145ChartAsync(request: GetRvd145ChartQuery): Promise<Array<Rvd145ChartDto>> {
      return this._requestHelper.getAsync<Array<Rvd145ChartDto>>("rvd145/getRvd145Chart", request);
   }

   public getRvd145LastAsync(request: GetRvd145LastQuery): Promise<Rvd145Dto> {
      return this._requestHelper.getAsync<Rvd145Dto>("rvd145/getRvd145Last", request);
   }
}
