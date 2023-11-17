<script setup lang="ts">
import { PropType } from 'vue';
import { PlcChartGroup } from '../../helpers/plcHelper';
import { Rvd145Dto } from '../../models/api/plcs/rvds/dto/rvd145Dto';
import { Rvd145ChartDto } from '../../models/api/plcs/rvds/dto/rvd145ChartDto';

const props = defineProps({
   data: {
      type: Object as PropType<PlcChartGroup<Rvd145Dto, Rvd145ChartDto>>,
      required: false,
   },
});
</script>

<template>{{ props.data?.device.name }}</template>
