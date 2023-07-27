<script setup lang="ts">
import { ComputedRef, Ref, computed, onMounted, onUnmounted, ref } from "vue";
import { UserApi } from "./api/userApi";
import { apiTokenRefreshInterval } from "./config";
import { authStore } from "./stores/authStore";

const store = authStore();
const userApi: UserApi = new UserApi();

const tokenInterval: Ref<number> = ref(0);
const isLogged: ComputedRef<boolean> = computed((): boolean => store.isLogged);

async function refreshTokenAsync(): Promise<void> {
   if (!isLogged.value) {
      return;
   }

   try {
      await userApi.getUserTokenRefreshAsync();
   } catch (error) {
      //TODO: move to toast
      console.warn(error);
   }
}

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
   <router-view />
</template>
