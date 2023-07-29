<script setup lang="ts">
import { Ref, onMounted, ref } from "vue";
import { useI18n } from "vue-i18n";
import { ClickEvent } from "devextreme/ui/button";
import { dateFormat } from "../config";
import { ReportApi } from "../api/reportApi";
import { getDateString } from "../helpers/dateHelper";
import { displayError } from "../helpers/toastHelper";
import { DictionaryItem } from "../models/api/base/dto/dictionaryItem";
import { GetReportQuery } from "../models/api/reports/queries/getReportQuery";
import { FileResult } from "../models/requests/fileResult";

const reportApi: ReportApi = new ReportApi();
const { t } = useI18n();

const isLoading: Ref<boolean> = ref(false);
const toastIsVisible: Ref<boolean> = ref(false);
const reportTypes: Ref<Array<DictionaryItem>> = ref([]);
const request: Ref<GetReportQuery> = ref({
   date: getDateString(new Date()),
   type: 1,
});

async function downloadReportClickAsync(e: ClickEvent): Promise<void> {
   try {
      isLoading.value = true;

      if (e.validationGroup?.validate()?.isValid != true) {
         return;
      }

      const result: FileResult = await reportApi.getReportAsync(request.value);
      if (!result.data?.size) {
         return;
      }

      const a: HTMLAnchorElement = document.createElement("a");
      a.href = URL.createObjectURL(result.data);
      a.setAttribute("download", result.name);
      a.click();
      a.remove();
   } catch (error) {
      displayError(
         error,
         () => {
            toastIsVisible.value = true;
         },
         () => {
            toastIsVisible.value = false;
         },
      );
   } finally {
      isLoading.value = false;
   }
}

onMounted(async (): Promise<void> => {
   try {
      isLoading.value = true;

      reportTypes.value = await reportApi.getReportTypeDictionaryAsync();
   } catch (error) {
      displayError(
         error,
         () => {
            toastIsVisible.value = true;
         },
         () => {
            toastIsVisible.value = false;
         },
      );
   } finally {
      isLoading.value = false;
   }
});
</script>

<template>
   <LoadPanel :visible="isLoading" />
   <div class="mx-auto py-5 card-report">
      <Card :show-header="false">
         <template #body>
            <div class="row pb-2">
               <div class="col text-center">
                  <i class="dx-icon-tableproperties text-center pt-4 card-icon" />
               </div>
            </div>
            <div class="row px-2 pt-4">
               <div class="col">
                  <DxValidationGroup>
                     <div class="dx-field">
                        <DxSelectBox
                           :data-source="reportTypes"
                           :disabled="isLoading || toastIsVisible"
                           display-expr="value"
                           value-expr="key"
                           v-model="request.type"
                           width="100%"
                        >
                           <DxValidator>
                              <DxRangeRule :ignore-empty-value="false" :message="t('views.report.form.validators.type.range')" :min="1" alignment="left" />
                           </DxValidator>
                        </DxSelectBox>
                     </div>
                     <div class="dx-field pt-2">
                        <DxDateBox
                           :acceptCustomValue="false"
                           :disabled="isLoading || toastIsVisible"
                           :display-format="dateFormat"
                           picker-type="calendar"
                           type="date"
                           v-model="request.date"
                           width="100%"
                        >
                           <DxValidator>
                              <DxRequiredRule :message="t('views.report.form.validators.date.required')" alignment="left" />
                           </DxValidator>
                        </DxDateBox>
                     </div>
                     <div class="dx-field pt-3 pb-2">
                        <DxButton
                           :disabled="isLoading || toastIsVisible"
                           :text="t('views.report.downloadButton')"
                           icon="check"
                           height="45px"
                           styling-mode="contained"
                           type="default"
                           width="100%"
                           @click="downloadReportClickAsync"
                        />
                     </div>
                  </DxValidationGroup>
               </div>
            </div>
         </template>
      </Card>
   </div>
</template>
