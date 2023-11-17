<script setup lang="ts">
import { PropType } from 'vue';
import { PlcChartGroup } from '../../helpers/plcHelper';
import { ClimatixDto } from '../../models/api/plcs/climatixs/dto/climatixDto';
import { ClimatixChartDto } from '../../models/api/plcs/climatixs/dto/climatixChartDto';

const props = defineProps({
   data: {
      type: Object as PropType<PlcChartGroup<ClimatixDto, ClimatixChartDto>>,
      required: false,
   },
});
</script>

<template>{{ props.data?.device.name }}</template>
