import { from } from 'linq-to-typescript';
import { PlcChartDtoBase } from '../models/api/base/dto/plcChartDtoBase';
import { PlcDtoBase } from '../models/api/base/dto/plcDtoBase';
import { PlcType } from '../models/api/devices/enums/plcType';
import { GetPlcChartDayQueryBase } from '../models/api/base/queries/getPlcChartDayQueryBase';
import { GetPlcLastQueryBase } from '../models/api/base/queries/getPlcLastQueryBase';
import { DeviceDto } from '../models/api/devices/dto/deviceDto';

export interface PlcChartGroup<P extends PlcDtoBase, C extends PlcChartDtoBase> {
   deviceId: number;
   plc: P | null;
   charts: Array<C>;
}

export function getPlcChartDayItemsAsync<P extends PlcDtoBase, C extends PlcChartDtoBase>(
   devices: Array<DeviceDto>,
   plcType: PlcType,
   plcLast: (plcRequest: GetPlcLastQueryBase) => Promise<P | null>,
   plcChart: (chartRequest: GetPlcChartDayQueryBase) => Promise<Array<C>>
): Promise<Array<PlcChartGroup<P, C>>> {
   return from(devices)
      .asParallel()
      .where((x) => x.plcType == plcType)
      .selectAsync((x) => getPlcChartDayItemAsync(x.id, plcLast, plcChart))
      .toArray();
}

async function getPlcChartDayItemAsync<P extends PlcDtoBase, C extends PlcChartDtoBase>(
   deviceId: number,
   plcLast: (plcRequest: GetPlcLastQueryBase) => Promise<P | null>,
   plcChart: (chartRequest: GetPlcChartDayQueryBase) => Promise<Array<C>>
): Promise<PlcChartGroup<P, C>> {
   const last = await plcLast({ deviceId: deviceId });
   if (!last) {
      return { deviceId: deviceId, plc: null, charts: [] };
   }

   const charts = await plcChart({ deviceId: deviceId, endDate: last.date });
   return { deviceId: deviceId, plc: last, charts: charts };
}
