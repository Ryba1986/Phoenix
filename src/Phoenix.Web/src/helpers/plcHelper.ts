import { from } from 'linq-to-typescript';
import { getDateString } from './dateHelper';
import { PlcChartDtoBase } from '../models/api/base/dto/plcChartDtoBase';
import { PlcDtoBase } from '../models/api/base/dto/plcDtoBase';
import { PlcType } from '../models/api/devices/enums/plcType';
import { GetPlcChartQueryBase } from '../models/api/base/queries/getPlcChartQueryBase';
import { GetPlcLastQueryBase } from '../models/api/base/queries/getPlcLastQueryBase';
import { DeviceDto } from '../models/api/devices/dto/deviceDto';

export interface PlcChartGroup<P extends PlcDtoBase, C extends PlcChartDtoBase> {
   device: DeviceDto;
   plc: P;
   charts: Array<C>;
}

export function getPlcChartItemsAsync<P extends PlcDtoBase, C extends PlcChartDtoBase>(
   devices: Array<DeviceDto>,
   plcType: PlcType,
   date: Date,
   plcLast: (plcRequest: GetPlcLastQueryBase) => Promise<P>,
   plcChart: (chartRequest: GetPlcChartQueryBase) => Promise<Array<C>>
): Promise<Array<PlcChartGroup<P, C>>> {
   return from(devices)
      .asParallel()
      .where((x) => x.plcType == plcType)
      .selectAsync((x) => getPlcChartItemAsync(x, date, plcLast, plcChart))
      .toArray();
}

async function getPlcChartItemAsync<P extends PlcDtoBase, C extends PlcChartDtoBase>(
   device: DeviceDto,
   date: Date,
   plcLast: (plcRequest: GetPlcLastQueryBase) => Promise<P>,
   plcChart: (chartRequest: GetPlcChartQueryBase) => Promise<Array<C>>
): Promise<PlcChartGroup<P, C>> {
   const result = await Promise.all([plcLast({ deviceId: device.id }), plcChart({ deviceId: device.id, date: getDateString(date) })]);
   return { device: device, plc: result[0], charts: result[1] };
}
