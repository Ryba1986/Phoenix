<script setup lang="ts">
const props = defineProps({
   showHeader: {
      type: Boolean,
      default: true,
   },
});
</script>

<template>
   <div class="card border-0 shadow-sm mb-3">
      <div v-if="props.showHeader" class="card-header bg-white">
         <slot name="header" />
      </div>
      <div class="card-body py-2">
         <slot name="body" />
      </div>
   </div>
</template>
