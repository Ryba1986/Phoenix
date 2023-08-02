import { from } from "linq-to-typescript";
import { GetPlcLastQueryBase } from "../models/api/base/queries/getPlcLastQueryBase";
import { DeviceDto } from "../models/api/devices/dto/deviceDto";

export function getPumpStatus(alarm: boolean, status: boolean): string {
   return alarm ? "#ff3333" : status ? "#00e200" : "#b5b3b2";
}

export function getSectionStatus(status: boolean): string {
   return status ? "visible" : "hidden";
}

export function getPlcFromLocationAsync<T>(
   devices: Array<DeviceDto>,
   plcType: number,
   plcLastAsync: (query: GetPlcLastQueryBase) => Promise<T | null>,
): Promise<Array<T>> {
   return from(devices)
      .asParallel()
      .where((x) => x.plcType == plcType)
      .selectAsync((x) => plcLastAsync({ deviceId: x.id }))
      .where((x) => x != null)
      .select((x) => x!)
      .toArray();
}
