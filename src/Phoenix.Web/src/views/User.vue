<script setup lang="ts">
import { Ref, ref } from 'vue';
import { useI18n } from 'vue-i18n';
import CustomStore from 'devextreme/data/custom_store';
import { getRoleDictionaryAsync } from '../api/roleApi';
import { getUsersAsync, createUserAsync, updateUserAsync, getUserHistoryAsync } from '../api/userApi';
import { DictionaryItem } from '../models/api/base/dto/dictionaryItem';

const { t } = useI18n();

const roles: Ref<Array<DictionaryItem>> = ref([]);

const userStore = new CustomStore<any, any>({
   key: "id",
   load: async () => {
      const result = await Promise.all([getRoleDictionaryAsync(), getUsersAsync()]);

      roles.value = result[0];
      return result[1];
   },
   insert: (value) => createUserAsync(value),
   update: (_key, value) => updateUserAsync(value),
});

const userHistoryStore = (userId: number) => {
   return new CustomStore<any, any>({
      key: undefined,
      load: () => getUserHistoryAsync({ userId: userId }),
   });
};
</script>

<template>
   <Card :show-header="false">
      <template #body>
         <DataGrid :data-store="userStore" :enable-detail="true">
            <template #columns>
               <DxGridColumn :caption="t('views.user.grid.columns.name')" data-field="name" data-type="string">
                  <DxStringLengthRule :ignore-empty-value="false" :message="t('views.user.grid.validators.name.length')" :min="3" :max="50" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.user.grid.columns.email')" data-field="email" data-type="string">
                  <DxEmailRule :ignore-empty-value="false" :message="t('views.user.grid.validators.email.email')" />
                  <DxStringLengthRule :ignore-empty-value="false" :message="t('views.user.grid.validators.email.length')" :min="3" :max="50" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.user.grid.columns.role')" data-field="roleId" data-type="number">
                  <DxGridLookup :data-source="roles" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.user.grid.validators.role.range')" :min="1" alignment="left" />
               </DxGridColumn>
            </template>
            <template #detailView="detailProps">
               <DataGrid :data-store="userHistoryStore(detailProps.key)" :allow-adding="false" :allow-updating="false" :enable-detail="false">
                  <template #columns>
                     <DxGridColumn :caption="t('views.user.grid.columns.name')" data-field="name" data-type="string" />
                     <DxGridColumn :caption="t('views.user.grid.columns.email')" data-field="email" data-type="string" />
                     <DxGridColumn :caption="t('views.user.grid.columns.role')" data-field="roleName" data-type="string" />
                  </template>
               </DataGrid>
            </template>
         </DataGrid>
      </template>
   </Card>
</template>
