import { getAsync, postAsync } from "../helpers/requestHelper";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { CreateLocationCommand } from "../models/api/locations/commands/createLocationCommand";
import { UpdateLocationCommand } from "../models/api/locations/commands/updateLocationCommand";
import { LocationDto } from "../models/api/locations/dto/locationDto";
import { LocationHistoryDto } from "../models/api/locations/dto/locationHistoryDto";
import { GetLocationHistoryQuery } from "../models/api/locations/queries/getLocationHistoryQuery";
import { Result } from "../models/requests/result";

export function getLocationsAsync(): Promise<Array<LocationDto>> {
   return getAsync<Array<LocationDto>>("location/getLocations");
}

export function getLocationHistoryAsync(request: GetLocationHistoryQuery): Promise<Array<LocationHistoryDto>> {
   return getAsync<Array<LocationHistoryDto>>("location/getLocationHistory", request);
}

export function getLocationDictionaryAsync(): Promise<Array<DictionaryItem>> {
   return getAsync<Array<DictionaryItem>>("location/getLocationDictionary");
}

export function createLocationAsync(command: CreateLocationCommand): Promise<Result> {
   return postAsync("location/createLocation", command);
}

export function updateLocationAsync(command: UpdateLocationCommand): Promise<Result> {
   return postAsync("location/updateLocation", command);
}
