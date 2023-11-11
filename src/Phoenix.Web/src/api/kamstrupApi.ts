import { getAsync } from '../helpers/requestHelper';
import { KamstrupChartDto } from '../models/api/plcs/kamstrups/dto/kamstrupChartDto';
import { KamstrupDto } from '../models/api/plcs/kamstrups/dto/kamstrupDto';
import { GetKamstrupChartQuery } from '../models/api/plcs/kamstrups/queries/getKamstrupChartQuery';
import { GetKamstrupLastQuery } from '../models/api/plcs/kamstrups/queries/getKamstrupLastQuery';

export function getKamstrupChartAsync(request: GetKamstrupChartQuery): Promise<Array<KamstrupChartDto>> {
   return getAsync<Array<KamstrupChartDto>>('kamstrup/getKamstrupChart', request);
}

export function getKamstrupLastAsync(request: GetKamstrupLastQuery): Promise<KamstrupDto> {
   return getAsync<KamstrupDto>('kamstrup/getKamstrupLast', request);
}
