import { getAsync } from '../helpers/requestHelper';
import { KamstrupChartDto } from '../models/api/plcs/meters/dto/kamstrupChartDto';
import { KamstrupDto } from '../models/api/plcs/meters/dto/kamstrupDto';
import { GetKamstrupChartQuery } from '../models/api/plcs/meters/queries/getKamstrupChartQuery';
import { GetKamstrupLastQuery } from '../models/api/plcs/meters/queries/getKamstrupLastQuery';

export function getKamstrupChartAsync(request: GetKamstrupChartQuery): Promise<Array<KamstrupChartDto>> {
   return getAsync<Array<KamstrupChartDto>>('kamstrup/getKamstrupChart', request);
}

export function getKamstrupLastAsync(request: GetKamstrupLastQuery): Promise<KamstrupDto | null> {
   return getAsync<KamstrupDto | null>('kamstrup/getKamstrupLast', request);
}
