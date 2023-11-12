<script setup lang="ts">
import { ComputedRef, Ref, computed, onMounted, onUnmounted, ref, watch } from 'vue';
import { dashboardRefreshInterval } from '../config';
import { getClimatixChartAsync, getClimatixLastAsync } from '../api/climatixApi';
import { getDevicesByLocationAsync } from '../api/deviceApi';
import { getKamstrupChartAsync, getKamstrupLastAsync } from '../api/kamstrupApi';
import { getLocationDictionaryAsync } from '../api/locationApi';
import { getRvd145ChartAsync, getRvd145LastAsync } from '../api/rvd145Api';
import { addDays } from '../helpers/dateHelper';
import { getPlcFromLocationAsync, getPlcChartFromLocationAsync } from '../helpers/plcHelper';
import { displayError } from '../helpers/toastHelper';
import { DeviceDto } from '../models/api/devices/dto/deviceDto';
import { ClimatixDto } from '../models/api/plcs/climatixs/dto/climatixDto';
import { ClimatixChartDto } from '../models/api/plcs/climatixs/dto/climatixChartDto';
import { KamstrupDto } from '../models/api/plcs/kamstrups/dto/kamstrupDto';
import { KamstrupChartDto } from '../models/api/plcs/kamstrups/dto/kamstrupChartDto';
import { Rvd145Dto } from '../models/api/plcs/rvds/dto/rvd145Dto';
import { Rvd145ChartDto } from '../models/api/plcs/rvds/dto/rvd145ChartDto';
import { dashboardStore } from '../stores/dashboardStore';

const dStore = dashboardStore();

const isLoading: Ref<boolean> = ref(false);
const isPageLoaded: Ref<boolean> = ref(false);
const locationId: ComputedRef<number> = computed((): number => dStore.locationId);
const refreshLocationInterval: Ref<number> = ref(0);

const devices: Ref<Array<DeviceDto>> = ref([]);
const climatixDtos: Ref<Array<ClimatixDto>> = ref([]);
const kamstrupDtos: Ref<Array<KamstrupDto>> = ref([]);
const rvd145Dtos: Ref<Array<Rvd145Dto>> = ref([]);
const climatixCharts: Ref<Array<ClimatixChartDto>> = ref([]);
const kamstrupCharts: Ref<Array<KamstrupChartDto>> = ref([]);
const rvd145Charts: Ref<Array<Rvd145ChartDto>> = ref([]);

async function getClimatixsAsync(startDate: Date): Promise<void> {
   const plcType: number = 2;
   climatixDtos.value = await getPlcFromLocationAsync(devices.value, plcType, getClimatixLastAsync);
   climatixCharts.value = await getPlcChartFromLocationAsync(devices.value, plcType, startDate, getClimatixChartAsync);
}

async function getKamstrupsAsync(startDate: Date): Promise<void> {
   const plcType: number = 1;
   kamstrupDtos.value = await getPlcFromLocationAsync(devices.value, plcType, getKamstrupLastAsync);
   kamstrupCharts.value = await getPlcChartFromLocationAsync(devices.value, plcType, startDate, getKamstrupChartAsync);
}

async function getRvd145sAsync(startDate: Date): Promise<void> {
   const plcType: number = 3;
   rvd145Dtos.value = await getPlcFromLocationAsync(devices.value, plcType, getRvd145LastAsync);
   rvd145Charts.value = await getPlcChartFromLocationAsync(devices.value, plcType, startDate, getRvd145ChartAsync);
}

async function refreshLocationAsync(): Promise<void> {
   try {
      isLoading.value = true;
      dStore.setLocations(await getLocationDictionaryAsync());
      devices.value = await getDevicesByLocationAsync({ locationId: locationId.value });

      const startDate: Date = addDays(new Date(), -1);
      await Promise.all([getClimatixsAsync(startDate), getKamstrupsAsync(startDate), getRvd145sAsync(startDate)]);
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
   Dashboard
</template>
