import { from } from 'linq-to-typescript';
import { getDateString } from './dateHelper';
import { Tuple } from '../models/api/base/tuple';
import { PlcChartDtoBase } from '../models/api/base/dto/plcChartDtoBase';
import { PlcDtoBase } from '../models/api/base/dto/plcDtoBase';
import { GetPlcChartQueryBase } from '../models/api/base/queries/getPlcChartQueryBase';
import { GetPlcLastQueryBase } from '../models/api/base/queries/getPlcLastQueryBase';
import { DeviceDto } from '../models/api/devices/dto/deviceDto';

export function getPlcChartItemsAsync<P extends PlcDtoBase, C extends PlcChartDtoBase>(
   devices: Array<DeviceDto>,
   plcType: number,
   date: Date,
   plcLast: (plcRequest: GetPlcLastQueryBase) => Promise<P>,
   plcChart: (chartRequest: GetPlcChartQueryBase) => Promise<Array<C>>
): Promise<Array<Tuple<P, Array<C>>>> {
   return from(devices)
      .asParallel()
      .where((x) => x.plcType == plcType)
      .selectAsync((x) => getPlcChartItemAsync(x, date, plcLast, plcChart))
      .toArray();
}

async function getPlcChartItemAsync<P, C>(
   device: DeviceDto,
   date: Date,
   plcLast: (plcRequest: GetPlcLastQueryBase) => Promise<P>,
   plcChart: (chartRequest: GetPlcChartQueryBase) => Promise<Array<C>>
): Promise<Tuple<P, Array<C>>> {
   const result = await Promise.all([plcLast({ deviceId: device.id }), plcChart({ deviceId: device.id, date: getDateString(date) })]);
   return { item1: result[0], item2: result[1] };
}
