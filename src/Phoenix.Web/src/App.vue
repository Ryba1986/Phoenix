<script setup lang="ts">
import { Ref, onMounted, onUnmounted, ref } from 'vue';
import { getUserTokenRefreshAsync } from './api/userApi';
import { apiTokenRefreshInterval } from './config';
import { displayError } from './helpers/toastHelper';
import { authStore } from './stores/authStore';

const store = authStore();
const tokenInterval: Ref<number> = ref(0);

async function refreshTokenAsync(): Promise<void> {
   if (!store.isLogged) {
      return;
   }

   try {
      await getUserTokenRefreshAsync();
   } catch (error) {
      displayError(error);
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
   <NavBar />
   <div class="container-fluid pt-4 px-3">
      <router-view />
   </div>
</template>
