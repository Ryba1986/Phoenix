<script setup lang="ts">
import { PropType } from "vue";
import { useI18n } from "vue-i18n";
import { getDateTimeShortString } from "../../helpers/dateHelper";
import { KamstrupDto } from "../../models/api/plcs/meters/dto/kamstrupDto";

const props = defineProps({
   plc: {
      type: Object as PropType<KamstrupDto>,
      default: {},
      required: true,
   },
});

const { t } = useI18n();
</script>

<template>
   <Card>
      <template #header>
         <div class="mt-1 text-muted">
            {{ props.plc.deviceName }}
            <div class="float-end">{{ getDateTimeShortString(props.plc.date) }}</div>
         </div>
      </template>
      <template #body>
         <table class="table table-sm table-borderless table-striped">
            <tbody>
               <tr>
                  <td class="text-muted">{{ t("components.kamstrup.inletTemp") }}</td>
                  <td class="text-end">{{ props.plc.inletTemp.toFixed(1) }}</td>
                  <td class="text-muted">&#8451;</td>
               </tr>
               <tr>
                  <td class="text-muted">{{ t("components.kamstrup.outletTemp") }}</td>
                  <td class="text-end">{{ props.plc.outletTemp.toFixed(1) }}</td>
                  <td class="text-muted">&#8451;</td>
               </tr>
               <tr>
                  <td class="text-muted">{{ t("components.kamstrup.power") }}</td>
                  <td class="text-end">{{ props.plc.power.toFixed(1) }}</td>
                  <td class="text-muted">kW</td>
               </tr>
               <tr>
                  <td class="text-muted">{{ t("components.kamstrup.volume") }}</td>
                  <td class="text-end">{{ props.plc.volume.toFixed(1) }}</td>
                  <td class="text-muted">m<sup>3</sup></td>
               </tr>
               <tr>
                  <td class="text-muted">{{ t("components.kamstrup.energySummary") }}</td>
                  <td class="text-end">{{ props.plc.energySummary.toFixed(1) }}</td>
                  <td class="text-muted">GJ</td>
               </tr>
               <tr>
                  <td class="text-muted">{{ t("components.kamstrup.volumeSummary") }}</td>
                  <td class="text-end">{{ props.plc.volumeSummary.toFixed(1) }}</td>
                  <td class="text-muted">m<sup>3</sup></td>
               </tr>
               <tr>
                  <td class="text-muted">{{ t("components.kamstrup.hourCount") }}</td>
                  <td class="text-end">{{ props.plc.hourCount.toFixed(1) }}</td>
                  <td class="text-muted">h</td>
               </tr>
            </tbody>
         </table>
      </template>
   </Card>
</template>
