import { ApiBase } from "./base/apiBase";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { CreateLocationCommand } from "../models/api/locations/commands/createLocationCommand";
import { UpdateLocationCommand } from "../models/api/locations/commands/updateLocationCommand";
import { LocationDto } from "../models/api/locations/dto/locationDto";
import { LocationHistoryDto } from "../models/api/locations/dto/locationHistoryDto";
import { GetLocationHistoryQuery } from "../models/api/locations/queries/getLocationHistoryQuery";
import { Result } from "../models/requests/result";

export class LocationApi extends ApiBase {
   constructor() {
      super();
   }

   public getLocationsAsync(): Promise<Array<LocationDto>> {
      return this._requestHelper.getAsync<Array<LocationDto>>("location/getLocations");
   }

   public getLocationHistoryAsync(request: GetLocationHistoryQuery): Promise<Array<LocationHistoryDto>> {
      return this._requestHelper.getAsync<Array<LocationHistoryDto>>("location/getLocationHistory", request);
   }

   public getLocationDictionaryAsync(): Promise<Array<DictionaryItem>> {
      return this._requestHelper.getAsync<Array<DictionaryItem>>("location/getLocationDictionary");
   }

   public createLocationAsync(command: CreateLocationCommand): Promise<Result> {
      return this._requestHelper.postAsync("location/createLocation", command);
   }

   public updateLocationAsync(command: UpdateLocationCommand): Promise<Result> {
      return this._requestHelper.postAsync("location/updateLocation", command);
   }
}
