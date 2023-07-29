<script setup lang="ts">
import { useI18n } from "vue-i18n";
import CustomStore from "devextreme/data/custom_store";
import { LocationApi } from "../api/locationApi";

const locationApi: LocationApi = new LocationApi();
const { t } = useI18n();

const locationStore = new CustomStore<any, any>({
   key: "id",
   load: () => locationApi.getLocationsAsync(),
   insert: (value) => locationApi.createLocationAsync(value),
   update: (_key, value) => locationApi.updateLocationAsync(value),
});

const locationHistoryStore = (locationId: number) => {
   return new CustomStore<any, any>({
      key: undefined,
      load: () => locationApi.getLocationHistoryAsync({ locationId: locationId }),
   });
};
</script>

<template>
   <Card :show-header="false">
      <template #body>
         <DataGrid :data-store="locationStore" :enable-detail="true">
            <template #columns>
               <DxGridColumn :caption="t('views.location.grid.columns.name')" data-field="name" data-type="string">
                  <DxStringLengthRule :ignore-empty-value="false" :message="t('views.location.grid.validators.name.length')" :min="3" :max="30" />
               </DxGridColumn>
               <DxGridColumn
                  :caption="t('views.location.grid.columns.includeReport')"
                  :value="false"
                  :width="100"
                  data-field="includeReport"
                  data-type="boolean"
               />
            </template>
            <template #detailView="detailProps">
               <DataGrid :data-store="locationHistoryStore(detailProps.key)" :allow-adding="false" :allow-updating="false" :enable-detail="false">
                  <template #columns>
                     <DxGridColumn :caption="t('views.location.grid.columns.name')" data-field="name" data-type="string" />
                     <DxGridColumn :caption="t('views.location.grid.columns.includeReport')" :width="100" data-field="includeReport" data-type="boolean" />
                  </template>
               </DataGrid>
            </template>
         </DataGrid>
      </template>
   </Card>
</template>
