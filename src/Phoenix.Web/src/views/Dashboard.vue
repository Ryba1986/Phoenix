<script setup lang="ts">
import { ComputedRef, Ref, computed, onMounted, onUnmounted, ref, watch } from 'vue';
import { dashboardRefreshInterval } from '../config';
import { getClimatixChartAsync, getClimatixLastAsync } from '../api/climatixApi';
import { getDevicesByLocationAsync } from '../api/deviceApi';
import { getKamstrupChartAsync, getKamstrupLastAsync } from '../api/kamstrupApi';
import { getLocationDictionaryAsync } from '../api/locationApi';
import { getRvd145ChartAsync, getRvd145LastAsync } from '../api/rvd145Api';
import { PlcChartGroup, getPlcChartItemsAsync } from '../helpers/plcHelper';
import { displayError } from '../helpers/toastHelper';
import { DeviceDto } from '../models/api/devices/dto/deviceDto';
import { PlcType } from '../models/api/devices/enums/plcType';
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
const climatixs: Ref<Array<PlcChartGroup<ClimatixDto, ClimatixChartDto>>> = ref([]);
const kamstrups: Ref<Array<PlcChartGroup<KamstrupDto, KamstrupChartDto>>> = ref([]);
const rvd145s: Ref<Array<PlcChartGroup<Rvd145Dto, Rvd145ChartDto>>> = ref([]);

async function getClimatixsAsync(date: Date): Promise<void> {
   climatixs.value = await getPlcChartItemsAsync(devices.value, PlcType.Climatix, date, getClimatixLastAsync, getClimatixChartAsync);
}

async function getKamstrupsAsync(date: Date): Promise<void> {
   kamstrups.value = await getPlcChartItemsAsync(devices.value, PlcType.Kamstrup, date, getKamstrupLastAsync, getKamstrupChartAsync);
}

async function getRvd145sAsync(date: Date): Promise<void> {
   rvd145s.value = await getPlcChartItemsAsync(devices.value, PlcType.Rvd145, date, getRvd145LastAsync, getRvd145ChartAsync);
}

async function refreshLocationAsync(): Promise<void> {
   try {
      isLoading.value = true;
      const chartDate: Date = new Date();

      dStore.setLocations(await getLocationDictionaryAsync());
      devices.value = await getDevicesByLocationAsync({ locationId: locationId.value });

      await Promise.all([getClimatixsAsync(chartDate), getKamstrupsAsync(chartDate), getRvd145sAsync(chartDate)]);
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
