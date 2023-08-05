<script setup lang="ts">
import { useI18n } from "vue-i18n";
import CustomStore from "devextreme/data/custom_store";
import { createRoleAsync, getRoleHistoryAsync, getRolesAsync, updateRoleAsync } from "../api/roleApi";

const { t } = useI18n();

const roleStore = new CustomStore<any, any>({
   key: "id",
   load: () => getRolesAsync(),
   insert: (value) => createRoleAsync(value),
   update: (_key, value) => updateRoleAsync(value),
});

const roleHistoryStore = (roleId: number) => {
   return new CustomStore<any, any>({
      key: undefined,
      load: () => getRoleHistoryAsync({ roleId: roleId }),
   });
};
</script>

<template>
   <Card :show-header="false">
      <template #body>
         <DataGrid :data-store="roleStore" :enable-detail="true">
            <template #columns>
               <DxGridColumn :caption="t('views.role.grid.columns.name')" data-field="name" data-type="string">
                  <DxStringLengthRule :ignore-empty-value="false" :message="t('views.role.grid.validators.name.length')" :min="3" :max="50" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.role.grid.columns.isAdmin')" :width="100" data-field="isAdmin" data-type="boolean">
                  <DxRequiredRule :message="t('views.role.grid.validators.isAdmin.required')" />
               </DxGridColumn>
            </template>
            <template #detailView="detailProps">
               <DataGrid :data-store="roleHistoryStore(detailProps.key)" :allow-adding="false" :allow-updating="false" :enable-detail="false">
                  <template #columns>
                     <DxGridColumn :caption="t('views.role.grid.columns.name')" data-field="name" data-type="string" />
                     <DxGridColumn :caption="t('views.role.grid.columns.isAdmin')" :width="100" data-field="isAdmin" data-type="boolean" />
                  </template>
               </DataGrid>
            </template>
         </DataGrid>
      </template>
   </Card>
</template>
