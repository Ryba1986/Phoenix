import { defineStore } from 'pinia';
import { from } from 'linq-to-typescript';
import { dashboardLocationIdName } from '../config';
import { DictionaryItem } from '../models/api/base/dto/dictionaryItem';
import { DashboardState } from '../models/stores/dashboardState';

export const dashboardStore = defineStore('dashboardStore', {
   state: (): DashboardState => {
      return {
         locationId: parseInt(localStorage.getItem(dashboardLocationIdName) ?? '0'),
         locations: [],
      };
   },
   getters: {
      nonEmptyLocations: (state): boolean => state.locations.length > 0,
   },
   actions: {
      setLocationId(value: number): void {
         localStorage.setItem(dashboardLocationIdName, value.toString());
         this.locationId = value;
      },
      setLocations(value: Array<DictionaryItem>): void {
         this.locations = value;

         if (from(value).any((x: DictionaryItem) => x.key == this.locationId)) {
            return;
         }

         this.setLocationId(from(value).firstOrDefault()?.key ?? 0);
      },
   },
});
