<script setup lang="ts">
import { LegendClickEvent } from 'devextreme/viz/chart';
import { chartPaletteName, timeFormat } from '../config';
import { toDateTimeString } from '../helpers/dateHelper';
import { PlcChartDtoBase } from '../models/api/base/dto/plcChartDtoBase';

const props = defineProps({
   data: {
      type: Array<PlcChartDtoBase>,
      required: true,
   },
});

function customizeTooltip(pointInfo: any): any {
   const result: HTMLDivElement = document.createElement('div');

   const dateRow: HTMLDivElement = document.createElement('div');
   dateRow.classList.add('row');
   dateRow.classList.add('chart-tooltip-row');

   const colDate: HTMLDivElement = document.createElement('div');
   colDate.classList.add('col-12');
   colDate.classList.add('text-center');
   colDate.classList.add('pb-2');
   colDate.classList.add('px-5');
   colDate.textContent = toDateTimeString(pointInfo.argument);
   dateRow.append(colDate);

   result.append(dateRow);

   pointInfo.points.forEach((item: any) => {
      const row: HTMLDivElement = document.createElement('div');
      row.classList.add('row');
      row.classList.add('chart-tooltip-row');
      row.style.color = item.point.getColor();

      const colLabel: HTMLDivElement = document.createElement('div');
      colLabel.classList.add('col-8');
      colLabel.textContent = item.seriesName;
      row.append(colLabel);

      const colValue: HTMLDivElement = document.createElement('div');
      colValue.classList.add('col-4');
      colValue.classList.add('text-end');
      colValue.textContent = item.value.toFixed(1);
      row.append(colValue);

      result.append(row);
   });

   return { html: result.innerHTML };
}

function legendClick(e: LegendClickEvent): void {
   e.target.isVisible() ? e.target.hide() : e.target.show();
}
</script>

<template>
   <DxChart :data-source="props.data" :palette="chartPaletteName" palette-extension-mode="blend" @legend-click="legendClick">
      <DxChartAnimation :enabled="false" />
      <DxChartArgumentAxis :aggregationGroupWidth="2" argumentType="datetime">
         <DxChartLabel>
            <DxChartFormat :type="timeFormat" />
         </DxChartLabel>
      </DxChartArgumentAxis>
      <DxChartCommonAxisSettings>
         <DxChartGrid :visible="true" />
      </DxChartCommonAxisSettings>
      <DxChartCommonSeriesSettings argument-field="date" type="spline">
         <DxChartPoint :visible="false" />
      </DxChartCommonSeriesSettings>
      <DxChartLegend horizontal-alignment="center" vertical-alignment="bottom" />
      <DxChartLoadingIndicator :enabled="true" />
      <slot name="series" />
      <DxChartSize :height="350" />
      <DxChartTooltip :customize-tooltip="customizeTooltip" :enabled="true" :shared="true">
         <DxChartFont :size="13" :weight="600" />
      </DxChartTooltip>
   </DxChart>
</template>
