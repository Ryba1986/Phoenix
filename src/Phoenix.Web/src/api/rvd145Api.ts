import { getAsync } from "../helpers/requestHelper";
import { Rvd145ChartDto } from "../models/api/plcs/rvds/dto/rvd145ChartDto";
import { Rvd145Dto } from "../models/api/plcs/rvds/dto/rvd145Dto";
import { GetRvd145ChartQuery } from "../models/api/plcs/rvds/queries/getRvd145ChartQuery";
import { GetRvd145LastQuery } from "../models/api/plcs/rvds/queries/getRvd145LastQuery";

export function getRvd145ChartAsync(request: GetRvd145ChartQuery): Promise<Array<Rvd145ChartDto>> {
   return getAsync<Array<Rvd145ChartDto>>("rvd145/getRvd145Chart", request);
}

export function getRvd145LastAsync(request: GetRvd145LastQuery): Promise<Rvd145Dto> {
   return getAsync<Rvd145Dto>("rvd145/getRvd145Last", request);
}
