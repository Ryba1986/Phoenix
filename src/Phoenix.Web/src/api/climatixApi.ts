import { getAsync } from '../helpers/requestHelper';
import { ClimatixChartDto } from '../models/api/plcs/climatixs/dto/climatixChartDto';
import { ClimatixDto } from '../models/api/plcs/climatixs/dto/climatixDto';
import { GetClimatixChartDayQuery } from '../models/api/plcs/climatixs/queries/getClimatixChartDayQuery';
import { GetClimatixLastQuery } from '../models/api/plcs/climatixs/queries/getClimatixLastQuery';

export function getClimatixChartDayAsync(request: GetClimatixChartDayQuery): Promise<Array<ClimatixChartDto>> {
   return getAsync<Array<ClimatixChartDto>>('climatix/getClimatixChartDay', request);
}

export function getClimatixLastAsync(request: GetClimatixLastQuery): Promise<ClimatixDto> {
   return getAsync<ClimatixDto>('climatix/getClimatixLast', request);
}
