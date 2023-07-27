<script setup lang="ts">
import { routerRoutes } from "../config";
import router from "../router";
import { authStore } from "../stores/authStore";

authStore().removeToken();
router.push(routerRoutes.signIn);
</script>

<template></template>
