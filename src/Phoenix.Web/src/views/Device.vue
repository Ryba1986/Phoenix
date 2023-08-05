<script setup lang="ts">
import { Ref, ref } from "vue";
import { useI18n } from "vue-i18n";
import CustomStore from "devextreme/data/custom_store";
import {
   createDeviceAsync,
   getDeviceBoundRateDictionaryAsync,
   getDeviceDataBitDictionaryAsync,
   getDeviceHistoryAsync,
   getDeviceParityDictionaryAsync,
   getDevicePlcTypeDictionaryAsync,
   getDeviceStopBitDictionaryAsync,
   getDeviceTypeDictionaryAsync,
   getDevicesAsync,
   updateDeviceAsync,
} from "../api/deviceApi";
import { getLocationDictionaryAsync } from "../api/locationApi";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";

const { t } = useI18n();

const locations: Ref<Array<DictionaryItem>> = ref([]);
const boundRates: Ref<Array<DictionaryItem>> = ref([]);
const dataBits: Ref<Array<DictionaryItem>> = ref([]);
const deviceTypes: Ref<Array<DictionaryItem>> = ref([]);
const parities: Ref<Array<DictionaryItem>> = ref([]);
const plcTypes: Ref<Array<DictionaryItem>> = ref([]);
const stopBits: Ref<Array<DictionaryItem>> = ref([]);

const deviceStore = new CustomStore<any, any>({
   key: "id",
   load: async () => {
      const result = await Promise.all([
         getLocationDictionaryAsync(),
         getDeviceBoundRateDictionaryAsync(),
         getDeviceDataBitDictionaryAsync(),
         getDeviceTypeDictionaryAsync(),
         getDeviceParityDictionaryAsync(),
         getDevicePlcTypeDictionaryAsync(),
         getDeviceStopBitDictionaryAsync(),
         getDevicesAsync(),
      ]);

      locations.value = result[0];
      boundRates.value = result[1];
      dataBits.value = result[2];
      deviceTypes.value = result[3];
      parities.value = result[4];
      plcTypes.value = result[5];
      stopBits.value = result[6];

      return result[7];
   },
   insert: (value) => createDeviceAsync(value),
   update: (_key, value) => updateDeviceAsync(value),
});

const deviceHistoryStore = (deviceId: number) => {
   return new CustomStore<any, any>({
      key: undefined,
      load: () => getDeviceHistoryAsync({ deviceId: deviceId }),
   });
};
</script>

<template>
   <Card :show-header="false">
      <template #body>
         <DataGrid :data-store="deviceStore" :enable-detail="true">
            <template #columns>
               <DxGridColumn :caption="t('views.device.grid.columns.location')" alignment="left" data-field="locationId" data-type="number">
                  <DxGridLookup :data-source="locations" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.device.grid.validators.location.range')" :min="1" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.device.grid.columns.name')" data-field="name" data-type="string">
                  <DxStringLengthRule :ignore-empty-value="false" :message="t('views.device.grid.validators.name.length')" :min="3" :max="50" />
               </DxGridColumn>
               <DxGridColumn
                  :allow-grouping="false"
                  :caption="t('views.device.grid.columns.plcType')"
                  alignment="left"
                  data-field="plcType"
                  data-type="number"
                  :width="120"
               >
                  <DxGridLookup :data-source="plcTypes" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.device.grid.validators.plcType.range')" :min="1" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.device.grid.columns.deviceType')" alignment="left" data-field="deviceType" data-type="number" :width="120">
                  <DxGridLookup :data-source="deviceTypes" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.device.grid.validators.deviceType.range')" :min="1" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.device.grid.columns.modbusId')" alignment="left" data-field="modbusId" data-type="number" :width="100">
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.device.grid.validators.modbusId.range')" :min="0" :max="254" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.device.grid.columns.boundRate')" alignment="left" data-field="boundRate" data-type="number" :width="100">
                  <DxGridLookup :data-source="boundRates" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.device.grid.validators.boundRate.range')" :min="1" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.device.grid.columns.dataBits')" alignment="left" data-field="dataBits" data-type="number" :width="100">
                  <DxGridLookup :data-source="dataBits" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.device.grid.validators.dataBits.range')" :min="1" />
               </DxGridColumn>
               <DxGridColumn
                  :allow-grouping="false"
                  :caption="t('views.device.grid.columns.parity')"
                  alignment="left"
                  data-field="parity"
                  data-type="number"
                  :width="100"
               >
                  <DxGridLookup :data-source="parities" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.device.grid.validators.parity.range')" :min="0" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.device.grid.columns.stopBits')" alignment="left" data-field="stopBits" data-type="number" :width="100">
                  <DxGridLookup :data-source="stopBits" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.device.grid.validators.stopBits.range')" :min="0" />
               </DxGridColumn>
               <DxGridColumn
                  :caption="t('views.device.grid.columns.includeReport')"
                  :value="false"
                  :width="80"
                  data-field="includeReport"
                  data-type="boolean"
               />
            </template>
            <template #detailView="detailProps">
               <DataGrid :data-store="deviceHistoryStore(detailProps.key)" :allow-adding="false" :allow-updating="false" :enable-detail="false">
                  <template #columns>
                     <DxGridColumn :caption="t('views.device.grid.columns.location')" data-field="locationName" data-type="string" />
                     <DxGridColumn :caption="t('views.device.grid.columns.name')" data-field="name" data-type="string" />
                     <DxGridColumn :caption="t('views.device.grid.columns.plcType')" data-field="plcType" data-type="string" />
                     <DxGridColumn :caption="t('views.device.grid.columns.deviceType')" data-field="deviceType" data-type="string" />
                     <DxGridColumn :caption="t('views.device.grid.columns.modbusId')" data-field="modbusId" data-type="string" />
                     <DxGridColumn :caption="t('views.device.grid.columns.boundRate')" data-field="boundRate" data-type="string" />
                     <DxGridColumn :caption="t('views.device.grid.columns.dataBits')" data-field="dataBits" data-type="string" />
                     <DxGridColumn :caption="t('views.device.grid.columns.parity')" data-field="parity" data-type="string" />
                     <DxGridColumn :caption="t('views.device.grid.columns.stopBits')" data-field="stopBits" data-type="string" />
                     <DxGridColumn :caption="t('views.device.grid.columns.includeReport')" :width="80" data-field="includeReport" data-type="boolean" />
                  </template>
               </DataGrid>
            </template>
         </DataGrid>
      </template>
   </Card>
</template>
