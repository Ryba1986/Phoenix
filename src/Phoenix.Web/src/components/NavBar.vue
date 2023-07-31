<script setup lang="ts">
import { ComputedRef, computed } from "vue";
import { useI18n } from "vue-i18n";
import { routerRoutes } from "../config";
import { collapseNavBar } from "../helpers/bootstrapHelper.ts";
import { authStore } from "../stores/authStore";

const aStore = authStore();
const { t } = useI18n();

const isLogged: ComputedRef<boolean> = computed((): boolean => aStore.isLogged);
</script>

<template>
   <nav class="navbar navbar-light bg-white navbar-expand-md shadow-sm">
      <div class="container-fluid">
         <router-link :to="routerRoutes.default" class="navbar-brand" @click="collapseNavBar">
            <img src="/logo.png" alt="logo" width="32" height="32" class="align-text-top me-1" />
         </router-link>
         <button
            class="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
         >
            <span class="navbar-toggler-icon"></span>
         </button>
         <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav ms-auto my-2 my-md-0">
               <li v-show="isLogged" class="nav-item mx-1">
                  <router-link :to="routerRoutes.dashboard" class="nav-link" @click="collapseNavBar">{{ t("components.navbar.dashboard") }}</router-link>
               </li>
               <li v-show="isLogged" class="nav-item mx-1">
                  <router-link :to="routerRoutes.report" class="nav-link" @click="collapseNavBar">{{ t("components.navbar.report") }}</router-link>
               </li>
               <li v-show="isLogged" class="nav-item dropdown mx-1">
                  <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                     {{ t("components.navbar.masterdata") }}
                  </a>
                  <ul class="dropdown-menu">
                     <li class="dropdown-item">
                        <router-link :to="routerRoutes.location" class="nav-link" @click="collapseNavBar">{{ t("components.navbar.location") }}</router-link>
                     </li>
                     <li class="dropdown-item">
                        <router-link :to="routerRoutes.client" class="nav-link" @click="collapseNavBar">{{ t("components.navbar.client") }}</router-link>
                     </li>
                     <li><hr class="dropdown-divider" /></li>
                     <li class="dropdown-item">
                        <router-link :to="routerRoutes.device" class="nav-link" @click="collapseNavBar">{{ t("components.navbar.device") }}</router-link>
                     </li>
                  </ul>
               </li>
               <li v-show="isLogged" class="nav-item dropdown mx-1">
                  <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                     {{ t("components.navbar.administration") }}
                  </a>
                  <ul class="dropdown-menu">
                     <li class="dropdown-item">
                        <router-link :to="routerRoutes.role" class="nav-link" @click="collapseNavBar">{{ t("components.navbar.role") }}</router-link>
                     </li>
                     <li class="dropdown-item">
                        <router-link :to="routerRoutes.rolePermission" class="nav-link" @click="collapseNavBar">
                           {{ t("components.navbar.rolePermission") }}
                        </router-link>
                     </li>
                     <li><hr class="dropdown-divider" /></li>
                     <li class="dropdown-item">
                        <router-link :to="routerRoutes.user" class="nav-link" @click="collapseNavBar">{{ t("components.navbar.user") }}</router-link>
                     </li>
                  </ul>
               </li>
               <li v-show="!isLogged" class="nav-item mx-1">
                  <router-link :to="routerRoutes.signIn" class="nav-link" @click="collapseNavBar">{{ t("components.navbar.signIn") }}</router-link>
               </li>
               <li v-show="isLogged" class="nav-item mx-1">
                  <router-link :to="routerRoutes.signOut" class="nav-link" @click="collapseNavBar">{{ t("components.navbar.signOut") }}</router-link>
               </li>
            </ul>
         </div>
      </div>
   </nav>
</template>
