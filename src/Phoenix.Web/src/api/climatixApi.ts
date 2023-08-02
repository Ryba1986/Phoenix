import { getAsync } from "../helpers/requestHelper";
import { ClimatixChartDto } from "../models/api/plcs/climatixs/dto/climatixChartDto";
import { ClimatixDto } from "../models/api/plcs/climatixs/dto/climatixDto";
import { GetClimatixChartQuery } from "../models/api/plcs/climatixs/queries/getClimatixChartQuery";
import { GetClimatixLastQuery } from "../models/api/plcs/climatixs/queries/getClimatixLastQuery";

export function getClimatixChartAsync(request: GetClimatixChartQuery): Promise<Array<ClimatixChartDto>> {
   return getAsync<Array<ClimatixChartDto>>("climatix/getClimatixChart", request);
}

export function getClimatixLastAsync(request: GetClimatixLastQuery): Promise<ClimatixDto> {
   return getAsync<ClimatixDto>("climatix/getClimatixLast", request);
}
