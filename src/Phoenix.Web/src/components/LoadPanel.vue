<script setup lang="ts">
import { useI18n } from "vue-i18n";
import { loadPanelDelay } from "../config";

const props = defineProps({
   visible: {
      type: Boolean,
      default: false,
   },
});

const { t } = useI18n();
</script>

<template>
   <DxLoadPanel :delay="loadPanelDelay" :message="t('components.loadPanel.message')" :shading="true" :visible="props.visible" shading-color="transparent" />
</template>
