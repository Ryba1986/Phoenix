import { getAsync } from '../helpers/requestHelper';
import { KamstrupChartDto } from '../models/api/plcs/kamstrups/dto/kamstrupChartDto';
import { KamstrupDto } from '../models/api/plcs/kamstrups/dto/kamstrupDto';
import { GetKamstrupChartDayQuery } from '../models/api/plcs/kamstrups/queries/getKamstrupChartDayQuery';
import { GetKamstrupLastQuery } from '../models/api/plcs/kamstrups/queries/getKamstrupLastQuery';

export function getKamstrupChartDayAsync(request: GetKamstrupChartDayQuery): Promise<Array<KamstrupChartDto>> {
   return getAsync<Array<KamstrupChartDto>>('kamstrup/getKamstrupChartDay', request);
}

export function getKamstrupLastAsync(request: GetKamstrupLastQuery): Promise<KamstrupDto> {
   return getAsync<KamstrupDto>('kamstrup/getKamstrupLast', request);
}
