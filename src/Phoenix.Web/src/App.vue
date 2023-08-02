<script setup lang="ts">
import { ComputedRef, Ref, computed, onBeforeMount, onMounted, onUnmounted, ref } from "vue";
import { useI18n } from "vue-i18n";
import { from } from "linq-to-typescript";
import { getUserTokenRefreshAsync } from "./api/userApi";
import { apiTokenRefreshInterval } from "./config";
import { displayError } from "./helpers/toastHelper";
import { authStore } from "./stores/authStore";

const store = authStore();
const { locale, availableLocales } = useI18n();

const tokenInterval: Ref<number> = ref(0);
const isLogged: ComputedRef<boolean> = computed((): boolean => store.isLogged);

async function refreshTokenAsync(): Promise<void> {
   if (!isLogged.value) {
      return;
   }

   try {
      await getUserTokenRefreshAsync();
   } catch (error) {
      displayError(error);
   }
}

onBeforeMount((): void => {
   const localeName: string | null = from(availableLocales).firstOrDefault((x: string) => x.includes(navigator.language));
   if (!localeName) {
      return;
   }

   locale.value = localeName;
});

onMounted(async (): Promise<void> => {
   await refreshTokenAsync();

   tokenInterval.value = setInterval(async (): Promise<void> => {
      await refreshTokenAsync();
   }, apiTokenRefreshInterval);
});

onUnmounted((): void => {
   clearInterval(tokenInterval.value);
});
</script>

<template>
   <NavBar />
   <div class="container-fluid pt-4 px-3">
      <router-view />
   </div>
</template>
