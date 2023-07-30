import { getAsync, postAsync } from "../helpers/requestHelper";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { CreateDeviceCommand } from "../models/api/devices/commands/createDeviceCommand";
import { UpdateDeviceCommand } from "../models/api/devices/commands/updateDeviceCommand";
import { DeviceDto } from "../models/api/devices/dto/deviceDto";
import { DeviceHistoryDto } from "../models/api/devices/dto/deviceHistoryDto";
import { GetDeviceHistoryQuery } from "../models/api/devices/queries/getDeviceHistoryQuery";
import { GetDevicesByLocationQuery } from "../models/api/devices/queries/getDevicesByLocationQuery";
import { Result } from "../models/requests/result";

export function getDevicesAsync(): Promise<Array<DeviceDto>> {
   return getAsync<Array<DeviceDto>>("device/getDevices");
}

export function getDevicesByLocationAsync(request: GetDevicesByLocationQuery): Promise<Array<DeviceDto>> {
   return getAsync<Array<DeviceDto>>("device/getDevicesByLocation", request);
}

export function getDeviceHistoryAsync(request: GetDeviceHistoryQuery): Promise<Array<DeviceHistoryDto>> {
   return getAsync<Array<DeviceHistoryDto>>("device/getDeviceHistory", request);
}

export function getDeviceTypeDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("device/getDeviceTypeDictionary");
}

export function getDevicePlcTypeDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("device/getDevicePlcTypeDictionary");
}

export function getDeviceBoundRateDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("device/getDeviceBoundRateDictionary");
}

export function getDeviceDataBitDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("device/getDeviceDataBitDictionary");
}

export function getDeviceParityDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("device/getDeviceParityDictionary");
}

export function getDeviceStopBitDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("device/getDeviceStopBitDictionary");
}

export function createDeviceAsync(command: CreateDeviceCommand): Promise<Result> {
   return postAsync("device/createDevice", command);
}

export function updateDeviceAsync(command: UpdateDeviceCommand): Promise<Result> {
   return postAsync("device/updateDevice", command);
}
