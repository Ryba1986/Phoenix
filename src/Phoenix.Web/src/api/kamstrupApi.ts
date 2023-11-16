import { getAsync } from '../helpers/requestHelper';
import { KamstrupChartDto } from '../models/api/plcs/meters/dto/kamstrupChartDto';
import { KamstrupDto } from '../models/api/plcs/meters/dto/kamstrupDto';
import { GetKamstrupChartDayQuery } from '../models/api/plcs/meters/queries/getKamstrupChartDayQuery';
import { GetKamstrupLastQuery } from '../models/api/plcs/meters/queries/getKamstrupLastQuery';

export function getKamstrupChartDayAsync(request: GetKamstrupChartDayQuery): Promise<Array<KamstrupChartDto>> {
   return getAsync<Array<KamstrupChartDto>>('kamstrup/getKamstrupChartDay', request);
}

export function getKamstrupLastAsync(request: GetKamstrupLastQuery): Promise<KamstrupDto | null> {
   return getAsync<KamstrupDto | null>('kamstrup/getKamstrupLast', request);
}
