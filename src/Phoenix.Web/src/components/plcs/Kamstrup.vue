<script setup lang="ts">
import { PropType } from "vue";
import { useI18n } from "vue-i18n";
import { getDateTimeShortString } from "../../helpers/dateHelper";
import { KamstrupDto } from "../../models/api/plcs/meters/dto/kamstrupDto";

const props = defineProps({
   data: {
      type: Object as PropType<Array<KamstrupDto>>,
      default: [],
      required: true,
   },
});

const { t } = useI18n();

function getMediumMeterSize(): number {
   return props.data.length > 1 ? 6 : 12;
}

function getDoubleExtraLargeMeterSize(): number {
   switch (props.data.length) {
      case 1:
         return 12;
      case 2:
         return 6;
      case 3:
         return 4;
      default:
         return 3;
   }
}
</script>

<template>
   <div class="row">
      <div v-for="plc in props.data" :class="`col-12 col-md-${getMediumMeterSize()} col-xxl-${getDoubleExtraLargeMeterSize()}`">
         <Card>
            <template #header>
               <div class="mt-1 text-muted">
                  {{ plc.deviceName }}
                  <div class="float-end">{{ getDateTimeShortString(plc.date) }}</div>
               </div>
            </template>
            <template #body>
               <table class="table table-sm table-borderless table-striped">
                  <tbody>
                     <tr>
                        <td>{{ t("components.kamstrup.inletTemp") }}</td>
                        <td class="text-end">{{ plc.inletTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.kamstrup.outletTemp") }}</td>
                        <td class="text-end">{{ plc.outletTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.kamstrup.power") }}</td>
                        <td class="text-end">{{ plc.power.toFixed(1) }}</td>
                        <td>kW</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.kamstrup.volume") }}</td>
                        <td class="text-end">{{ plc.volume.toFixed(1) }}</td>
                        <td>m<sup>3</sup></td>
                     </tr>
                     <tr>
                        <td>{{ t("components.kamstrup.energySummary") }}</td>
                        <td class="text-end">{{ plc.energySummary.toFixed(1) }}</td>
                        <td>GJ</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.kamstrup.volumeSummary") }}</td>
                        <td class="text-end">{{ plc.volumeSummary.toFixed(1) }}</td>
                        <td>m<sup>3</sup></td>
                     </tr>
                     <tr>
                        <td>{{ t("components.kamstrup.hourCount") }}</td>
                        <td class="text-end">{{ plc.hourCount.toFixed(1) }}</td>
                        <td>h</td>
                     </tr>
                  </tbody>
               </table>
            </template>
         </Card>
      </div>
   </div>
</template>
