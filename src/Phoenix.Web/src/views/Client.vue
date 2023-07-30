<script setup lang="ts">
import { Ref, ref } from "vue";
import { useI18n } from "vue-i18n";
import CustomStore from "devextreme/data/custom_store";
import { createClientAsync, getClientHistoryAsync, getClientsAsync, updateClientAsync } from "../api/clientApi";
import { getLocationDictionaryAsync } from "../api/locationApi";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";

const { t } = useI18n();

const locations: Ref<Array<DictionaryItem>> = ref([]);

const clientStore = new CustomStore<any, any>({
   key: "id",
   load: async () => {
      const result = await Promise.all([getLocationDictionaryAsync(), getClientsAsync()]);

      locations.value = result[0];
      return result[1];
   },
   insert: (value) => createClientAsync(value),
   update: (_key, value) => updateClientAsync(value),
});

const clientHistoryStore = (clientId: number) => {
   return new CustomStore<any, any>({
      key: undefined,
      load: () => getClientHistoryAsync({ clientId: clientId }),
   });
};
</script>

<template>
   <Card :show-header="false">
      <template #body>
         <DataGrid :data-store="clientStore" :enable-detail="true">
            <template #columns>
               <DxGridColumn
                  :allow-grouping="false"
                  :caption="t('views.client.grid.columns.location')"
                  alignment="left"
                  data-field="locationId"
                  data-type="number"
               >
                  <DxGridLookup :data-source="locations" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignoreEmptyValue="false" :message="t('views.client.grid.validators.location.range')" :min="1" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.client.grid.columns.macAddress')" data-field="macAddress" data-type="string">
                  <DxPatternRule :ignoreEmptyValue="false" :message="t('views.client.grid.validators.macAddress.pattern')" pattern="^[0-9A-F]{12}$" />
               </DxGridColumn>
               <DxGridColumn :allow-editing="false" :caption="t('views.client.grid.columns.hostname')" :width="450" data-field="hostname" data-type="string" />
               <DxGridColumn :allow-editing="false" :caption="t('views.client.grid.columns.clientVersion')" data-field="clientVersion" data-type="string" />
            </template>
            <template #detailView="detailProps">
               <DataGrid :data-store="clientHistoryStore(detailProps.key)" :allow-adding="false" :allow-updating="false" :enable-detail="false">
                  <template #columns>
                     <DxGridColumn :caption="t('views.client.grid.columns.location')" data-field="locationName" data-type="string" />
                     <DxGridColumn :caption="t('views.client.grid.columns.macAddress')" data-field="macAddress" data-type="string" />
                  </template>
               </DataGrid>
            </template>
         </DataGrid>
      </template>
   </Card>
</template>
