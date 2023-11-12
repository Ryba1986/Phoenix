import { from } from 'linq-to-typescript';
import { DeviceDto } from '../models/api/devices/dto/deviceDto';
import { GetPlcChartQueryBase } from '../models/api/base/queries/getPlcChartQueryBase';
import { GetPlcLastQueryBase } from '../models/api/base/queries/getPlcLastQueryBase';

export function getPlcFromLocationAsync<T>(devices: Array<DeviceDto>, plcType: number, plcLastAsync: (query: GetPlcLastQueryBase) => Promise<T | null>): Promise<Array<T>> {
   return from(devices)
      .asParallel()
      .where((x) => x.plcType == plcType)
      .selectAsync((x) => plcLastAsync({ deviceId: x.id }))
      .where((x) => x != null)
      .select((x) => x!)
      .toArray();
}

export function getPlcChartFromLocationAsync<T>(devices: Array<DeviceDto>, plcType: number, startDate: Date, plcChartAsync: (query: GetPlcChartQueryBase) => Promise<Array<T>>): Promise<Array<T>> {
   return from(devices)
      .asParallel()
      .where((x) => x.plcType == plcType)
      .selectAsync((x) => plcChartAsync({ deviceId: x.id, date: startDate.toISOString() }))
      .selectMany((x) => x)
      .toArray();
}
