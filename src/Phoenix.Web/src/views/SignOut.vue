<script setup lang="ts">
import { authStore } from "../stores/authStore";

authStore().removeToken();
</script>

<template>Sign out</template>
