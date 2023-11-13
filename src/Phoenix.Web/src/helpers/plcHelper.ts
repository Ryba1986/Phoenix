import { from } from 'linq-to-typescript';
import { getDateString } from './dateHelper';
import { PlcChartDtoBase } from '../models/api/base/dto/plcChartDtoBase';
import { PlcDtoBase } from '../models/api/base/dto/plcDtoBase';
import { GetPlcChartQueryBase } from '../models/api/base/queries/getPlcChartQueryBase';
import { GetPlcLastQueryBase } from '../models/api/base/queries/getPlcLastQueryBase';
import { DeviceDto } from '../models/api/devices/dto/deviceDto';

export function getPlcFromLocationAsync<T extends PlcDtoBase>(devices: Array<DeviceDto>, plcType: number, plcLastAsync: (query: GetPlcLastQueryBase) => Promise<T | null>): Promise<Array<T>> {
   return from(devices)
      .asParallel()
      .where((x) => x.plcType == plcType)
      .selectAsync((x) => plcLastAsync({ deviceId: x.id }))
      .where((x) => x != null)
      .select((x) => x!)
      .toArray();
}

export function getPlcChartFromLocationAsync<T extends PlcChartDtoBase>(
   devices: Array<DeviceDto>,
   plcType: number,
   date: Date,
   plcChartAsync: (query: GetPlcChartQueryBase) => Promise<Array<T>>
): Promise<Array<T>> {
   return from(devices)
      .asParallel()
      .where((x) => x.plcType == plcType)
      .selectManyAsync((x) => plcChartAsync({ deviceId: x.id, date: getDateString(date) }))
      .toArray();
}
