<script setup lang="ts">
import { ComputedRef, Ref, computed, onMounted, onUnmounted, ref, watch } from "vue";
import { useI18n } from "vue-i18n";
import { getClimatixLastAsync } from "../api/climatixApi";
import { getDevicesByLocationAsync } from "../api/deviceApi";
import { getKamstrupLastAsync } from "../api/kamstrupApi";
import { getLocationDictionaryAsync } from "../api/locationApi";
import { getRvd145LastAsync } from "../api/rvd145Api";
import { dashboardRefreshInterval } from "../config";
import { getMeterDoubleExtraLargeSize, getMeterMediumSize, getPlcFromLocationAsync } from "../helpers/plcHelper";
import { displayError } from "../helpers/toastHelper";
import { DeviceDto } from "../models/api/devices/dto/deviceDto";
import { ClimatixDto } from "../models/api/plcs/climatixs/dto/climatixDto";
import { KamstrupDto } from "../models/api/plcs/meters/dto/kamstrupDto";
import { Rvd145Dto } from "../models/api/plcs/rvds/dto/rvd145Dto";
import { dashboardStore } from "../stores/dashboardStore";

const isLoading: Ref<boolean> = ref(false);
const isPageLoaded: Ref<boolean> = ref(false);
const refreshLocationInterval: Ref<number> = ref(0);

const devices: Ref<Array<DeviceDto>> = ref([]);
const climatixs: Ref<Array<ClimatixDto>> = ref([]);
const kamstrups: Ref<Array<KamstrupDto>> = ref([]);
const rvd145s: Ref<Array<Rvd145Dto>> = ref([]);

const dStore = dashboardStore();
const { t } = useI18n();

const isPlcData: ComputedRef<boolean> = computed(
   (): boolean => !(isPageLoaded.value && climatixs.value.length == 0 && kamstrups.value.length == 0 && rvd145s.value.length == 0),
);
const locationId: ComputedRef<number> = computed((): number => dStore.locationId);

async function getClimatixsAsync(): Promise<void> {
   climatixs.value = await getPlcFromLocationAsync(devices.value, 2, getClimatixLastAsync);
}

async function getKamstrupsAsync(): Promise<void> {
   kamstrups.value = await getPlcFromLocationAsync(devices.value, 1, getKamstrupLastAsync);
}

async function getRvd145sAsync(): Promise<void> {
   rvd145s.value = await getPlcFromLocationAsync(devices.value, 3, getRvd145LastAsync);
}

async function refreshLocationAsync(): Promise<void> {
   try {
      isLoading.value = true;
      dStore.setLocations(await getLocationDictionaryAsync());
      devices.value = await getDevicesByLocationAsync({ locationId: locationId.value });
      await Promise.all([getClimatixsAsync(), getKamstrupsAsync(), getRvd145sAsync()]);
   } catch (error) {
      displayError(error);
   } finally {
      isLoading.value = false;
   }
}

async function setRefreshIntervalAsync(): Promise<void> {
   clearInterval(refreshLocationInterval.value);
   await refreshLocationAsync();

   refreshLocationInterval.value = setInterval(async (): Promise<void> => {
      await refreshLocationAsync();
   }, dashboardRefreshInterval);
}

watch(locationId, async (): Promise<void> => {
   if (!isPageLoaded.value) {
      return;
   }

   await setRefreshIntervalAsync();
});

onMounted(async (): Promise<void> => {
   await setRefreshIntervalAsync();
   isPageLoaded.value = true;
});

onUnmounted((): void => {
   clearInterval(refreshLocationInterval.value);
});
</script>

<template>
   <LoadPanel :visible="isLoading" />
   <div v-if="!isPlcData" class="row py-5">
      <div class="col-12">
         <h4 class="text-center">{{ t("views.dashboard.emptyData") }}</h4>
      </div>
   </div>
   <div v-if="climatixs.length > 0" class="row">
      <div v-for="climatix in climatixs" class="cell-12">
         <Climatix :plc="climatix" />
      </div>
   </div>
   <div v-if="rvd145s.length > 0" class="row">
      <div v-for="rvd145 in rvd145s" class="cell-12">
         <Rvd145 :plc="rvd145" />
      </div>
   </div>
   <div v-if="kamstrups.length > 0" class="row">
      <div
         v-for="kamstrup in kamstrups"
         :class="`col-12 col-md-${getMeterMediumSize(kamstrups.length)} col-xxl-${getMeterDoubleExtraLargeSize(kamstrups.length)}`"
      >
         <Kamstrup :plc="kamstrup" />
      </div>
   </div>
</template>
