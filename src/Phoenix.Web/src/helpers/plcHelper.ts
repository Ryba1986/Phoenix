import { from } from "linq-to-typescript";
import { PlcDtoBase } from "../models/api/base/dto/plcDtoBase";
import { GetPlcLastQueryBase } from "../models/api/base/queries/getPlcLastQueryBase";
import { DeviceDto } from "../models/api/devices/dto/deviceDto";

export function getMeterDoubleExtraLargeSize(meterCount: number): number {
   switch (meterCount) {
      case 1:
         return 12;
      case 2:
         return 6;
      case 3:
         return 4;
      default:
         return 3;
   }
}

export function getMeterMediumSize(meterCount: number): number {
   return meterCount > 1 ? 6 : 12;
}

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

export function isHeatingPlcType(plc: PlcDtoBase): boolean {
   return plc.deviceType == 10;
}

export function isDoubleHeatingPlcType(plc: PlcDtoBase): boolean {
   return plc.deviceType == 20;
}

export function isDomesticPlcType(plc: PlcDtoBase): boolean {
   return plc.deviceType == 30;
}
