<script setup lang="ts">
import { PropType, Ref, ref } from "vue";
import { useI18n } from "vue-i18n";
import { DxDataGrid } from "devextreme-vue/data-grid";
import CustomStore from "devextreme/data/custom_store";
import { RowExpandingEvent, RowUpdatingEvent } from "devextreme/ui/data_grid";
import { dateTimeFormat } from "../config";

const props = defineProps({
   dataStore: {
      type: Object as PropType<CustomStore<any, any>>,
      default: {},
      required: true,
   },
   allowAdding: {
      type: Boolean,
      default: true,
   },
   allowUpdating: {
      type: Boolean,
      default: true,
   },
   enableDetail: {
      type: Boolean,
      default: false,
   },
});

const grid: Ref<DxDataGrid> = ref({});

const { t } = useI18n();

async function refreshEventAsync(): Promise<void> {
   const instance = grid.value.instance!;

   instance.cancelEditData();
   instance.clearSelection();
   instance.collapseAll(-1);
   instance.clearFilter();
   await instance.pageIndex(0);
   await instance.refresh();
}

function rowExpandingEvent(e: RowExpandingEvent): void {
   e.component.collapseAll(-1);
}

function rowUpdatingEvent(e: RowUpdatingEvent): void {
   e.newData = Object.assign({}, e.oldData, e.newData);
}
</script>

<template>
   <DxDataGrid
      :allow-column-reordering="false"
      :column-auto-width="true"
      :data-source="props.dataStore"
      :hover-state-enabled="true"
      :repaint-changes-only="false"
      :show-borders="true"
      :show-row-lines="false"
      ref="grid"
      @row-expanding="rowExpandingEvent"
      @row-updating="rowUpdatingEvent"
   >
      <DxGridEditing :allow-adding="props.allowAdding" :allow-updating="props.allowUpdating" :allow-deleting="false" mode="row" />
      <DxGridFilterRow :visible="true" apply-filter="auto" />
      <DxGridPager :show-info="false" :show-page-size-selector="false" :show-navigation-buttons="true" :visible="true" display-mode="full" />
      <DxGridPaging :page-size="17" />
      <DxGridSorting mode="single" />
      <DxGridToolbar>
         <DxGridItem location="after" template="gridRefresh" />
         <DxGridItem location="after" name="addRowButton" />
      </DxGridToolbar>
      <template #gridRefresh>
         <DxButton icon="refresh" @click="refreshEventAsync" />
      </template>
      <slot name="columns" />
      <DxGridColumn :caption="t('components.dataGrid.columns.isActive')" :value="false" :width="100" data-field="isActive" data-type="boolean" />
      <DxGridColumn
         v-if="!props.enableDetail"
         :caption="t('components.dataGrid.columns.createdBy')"
         :width="200"
         data-field="createdByName"
         data-type="string"
      />
      <DxGridColumn
         v-if="!props.enableDetail"
         :caption="t('components.dataGrid.columns.createDate')"
         :format="dateTimeFormat"
         :width="160"
         data-field="createDate"
         data-type="date"
      />
      <DxGridMasterDetail :enabled="props.enableDetail" template="detailTemplate" />
      <template #detailTemplate="{ data }">
         <div class="p-3 bg-white border">
            <slot name="detailView" :key="data.key" />
         </div>
      </template>
   </DxDataGrid>
</template>