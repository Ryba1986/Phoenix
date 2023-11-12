import { from } from 'linq-to-typescript';
import { DeviceDto } from '../models/api/devices/dto/deviceDto';
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
