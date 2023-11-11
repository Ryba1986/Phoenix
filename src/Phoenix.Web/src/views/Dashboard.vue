<script setup lang="ts">
import { ComputedRef, Ref, computed, onMounted, onUnmounted, ref, watch } from 'vue';
import { dashboardRefreshInterval } from '../config';
import { dashboardStore } from '../stores/dashboardStore';
import { getLocationDictionaryAsync } from '../api/locationApi';
import { displayError } from '../helpers/toastHelper';

const dStore = dashboardStore();

const isLoading: Ref<boolean> = ref(false);
const isPageLoaded: Ref<boolean> = ref(false);
const refreshLocationInterval: Ref<number> = ref(0);

const locationId: ComputedRef<number> = computed((): number => dStore.locationId);

async function refreshLocationAsync(): Promise<void> {
   try {
      isLoading.value = true;
      dStore.setLocations(await getLocationDictionaryAsync());
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

<template>Dashboard</template>
