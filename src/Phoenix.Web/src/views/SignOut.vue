<script setup lang="ts">
import { apiTokenEmptyValue } from '../config';
import { authStore } from '../stores/authStore';

authStore().setToken(apiTokenEmptyValue);
</script>

<template>Sign out</template>
