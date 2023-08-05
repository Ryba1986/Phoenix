<script setup lang="ts">
import { Ref, ref } from "vue";
import { useI18n } from "vue-i18n";
import CustomStore from "devextreme/data/custom_store";
import { getRoleDictionaryAsync } from "../api/roleApi";
import {
   createRolePermissionAsync,
   getAccessLevelDictionaryAsync,
   getPermissionDictionaryAsync,
   getRolePermissionsAsync,
   updateRolePermissionAsync,
} from "../api/rolePermissionApi";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";

const { t } = useI18n();

const roles: Ref<Array<DictionaryItem>> = ref([]);
const accessLevels: Ref<Array<DictionaryItem>> = ref([]);
const permissions: Ref<Array<DictionaryItem>> = ref([]);

const rolePermissionStore = new CustomStore<any, any>({
   key: "id",
   load: async () => {
      const result = await Promise.all([getRoleDictionaryAsync(), getAccessLevelDictionaryAsync(), getPermissionDictionaryAsync(), getRolePermissionsAsync()]);

      roles.value = result[0];
      accessLevels.value = result[1];
      permissions.value = result[2];

      return result[3];
   },
   insert: (value) => createRolePermissionAsync(value),
   update: (_key, value) => updateRolePermissionAsync(value),
});
</script>

<template>
   <Card :show-header="false">
      <template #body>
         <DataGrid :data-store="rolePermissionStore" :enable-detail="false" :show-is-active="false" :show-metrics="false">
            <template #columns>
               <DxGridColumn :caption="t('views.rolePermission.grid.columns.role')" alignment="left" data-field="roleId" data-type="number">
                  <DxGridLookup :data-source="roles" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.rolePermission.grid.validators.role.range')" :min="1" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.rolePermission.grid.columns.permission')" alignment="left" data-field="permission" data-type="number">
                  <DxGridLookup :data-source="permissions" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.rolePermission.grid.validators.permission.range')" :min="1" />
               </DxGridColumn>
               <DxGridColumn :caption="t('views.rolePermission.grid.columns.accessLevel')" alignment="left" data-field="accessLevel" data-type="number">
                  <DxGridLookup :data-source="accessLevels" display-expr="value" value-expr="key" />
                  <DxRangeRule :ignore-empty-value="false" :message="t('views.rolePermission.grid.validators.accessLevel.range')" :min="0" />
               </DxGridColumn>
            </template>
         </DataGrid>
      </template>
   </Card>
</template>
