<script setup lang="ts">
import { PropType, Ref, ref } from 'vue';
import { useI18n } from 'vue-i18n';
import CustomStore from 'devextreme/data/custom_store';
import { RowExpandingEvent, RowUpdatingEvent } from 'devextreme/ui/data_grid';
import DxDataGrid from 'devextreme-vue/data-grid';
import { dateTimeFormat } from '../config';

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
   showIsActive: {
      type: Boolean,
      default: true,
   },
   showMetrics: {
      type: Boolean,
      default: false,
   },
});

const { t } = useI18n();
const grid: Ref<DxDataGrid> = ref({});

function gridRefresh(): void {
   if (!grid.value.instance) {
      return;
   }

   grid.value.instance.cancelEditData();
   grid.value.instance.clearSelection();
   grid.value.instance.collapseAll(-1);
   grid.value.instance.clearFilter();
   grid.value.instance.pageIndex(0);
   grid.value.instance.refresh();
}

function gridRowExpanding(e: RowExpandingEvent): void {
   e.component.collapseAll(-1);
}

function gridRowUpdating(e: RowUpdatingEvent): void {
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
      :show-row-lines="true"
      ref="grid"
      @row-expanding="gridRowExpanding"
      @row-updating="gridRowUpdating"
   >
      <DxGridEditing :allow-adding="props.allowAdding" :allow-updating="props.allowUpdating" :allow-deleting="false" mode="row" />
      <DxGridFilterRow :visible="true" apply-filter="auto" />
      <DxGridMasterDetail :enabled="props.enableDetail" template="detailTemplate" />
      <template #detailTemplate="{ data }">
         <div class="p-3 bg-white border">
            <slot name="detail" :key="data.key" />
         </div>
      </template>
      <DxGridPager :show-info="false" :show-page-size-selector="false" :show-navigation-buttons="true" :visible="true" display-mode="full" />
      <DxGridPaging :page-size="props.enableDetail ? 17 : 5" />
      <DxGridSorting mode="single" />
      <DxGridToolbar>
         <DxGridItem location="after" template="gridRefresh" />
         <DxGridItem location="after" name="addRowButton" />
      </DxGridToolbar>
      <template #gridRefresh>
         <DxButton icon="refresh" @click="gridRefresh" />
      </template>
      <slot name="columns" />
      <DxGridColumn v-if="props.showIsActive" :caption="t('components.dataGrid.columns.isActive')" :value="false" :width="80" data-field="isActive" data-type="boolean" />
      <DxGridColumn v-if="props.showMetrics" :caption="t('components.dataGrid.columns.createdBy')" :width="150" data-field="createdByName" data-type="string" />
      <DxGridColumn v-if="props.showMetrics" :caption="t('components.dataGrid.columns.createDate')" :format="dateTimeFormat" :width="150" data-field="createDate" data-type="date" />
   </DxDataGrid>
</template>
