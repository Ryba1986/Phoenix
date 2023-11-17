<script setup lang="ts">
import { PropType } from 'vue';
import { PlcChartGroup } from '../../helpers/plcHelper';
import { KamstrupDto } from '../../models/api/plcs/meters/dto/kamstrupDto';
import { KamstrupChartDto } from '../../models/api/plcs/meters/dto/kamstrupChartDto';

const props = defineProps({
   data: {
      type: Object as PropType<PlcChartGroup<KamstrupDto, KamstrupChartDto>>,
      required: false,
   },
});
</script>

<template>{{ props.data?.device.name }}</template>
