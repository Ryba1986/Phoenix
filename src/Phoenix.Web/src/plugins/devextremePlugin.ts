import { App, Plugin } from 'vue';

import { DxButton } from 'devextreme-vue/button';
import { DxDateBox } from 'devextreme-vue/date-box';
import { DxLoadPanel } from 'devextreme-vue/load-panel';
import { DxSelectBox } from 'devextreme-vue/select-box';
import { DxTextBox } from 'devextreme-vue/text-box';

import {
   DxAnimation as DxChartAnimation,
   DxAggregation as DxChartAggregation,
   DxArgumentAxis as DxChartArgumentAxis,
   DxChart,
   DxCommonSeriesSettings as DxChartCommonSeriesSettings,
   DxCommonAxisSettings as DxChartCommonAxisSettings,
   DxFont as DxChartFont,
   DxGrid as DxChartGrid,
   DxFormat as DxChartFormat,
   DxLabel as DxChartLabel,
   DxLegend as DxChartLegend,
   DxLoadingIndicator as DxChartLoadingIndicator,
   DxPoint as DxChartPoint,
   DxSeries as DxChartSeries,
   DxSize as DxChartSize,
   DxTooltip as DxChartTooltip,
} from 'devextreme-vue/chart';

import {
   DxColumn as DxGridColumn,
   DxDataGrid,
   DxEditing as DxGridEditing,
   DxFilterRow as DxGridFilterRow,
   DxGroupPanel as DxGridGroupPanel,
   DxGrouping as DxGridGrouping,
   DxItem as DxGridItem,
   DxLookup as DxGridLookup,
   DxMasterDetail as DxGridMasterDetail,
   DxPager as DxGridPager,
   DxPaging as DxGridPaging,
   DxSorting as DxGridSorting,
   DxToolbar as DxGridToolbar,
} from 'devextreme-vue/data-grid';

import { DxValidationGroup } from 'devextreme-vue/validation-group';
import { DxEmailRule, DxPatternRule, DxRangeRule, DxRequiredRule, DxStringLengthRule, DxValidator } from 'devextreme-vue/validator';

export const devextremePlugin: Plugin = {
   install(app: App<Element>): void {
      app.component('DxButton', DxButton);
      app.component('DxDateBox', DxDateBox);
      app.component('DxLoadPanel', DxLoadPanel);
      app.component('DxSelectBox', DxSelectBox);
      app.component('DxTextBox', DxTextBox);

      app.component('DxChartAnimation', DxChartAnimation);
      app.component('DxChartAggregation', DxChartAggregation);
      app.component('DxChartArgumentAxis', DxChartArgumentAxis);
      app.component('DxChart', DxChart);
      app.component('DxChartCommonSeriesSettings', DxChartCommonSeriesSettings);
      app.component('DxChartCommonAxisSettings', DxChartCommonAxisSettings);
      app.component('DxChartGrid', DxChartGrid);
      app.component('DxChartFont', DxChartFont);
      app.component('DxChartFormat', DxChartFormat);
      app.component('DxChartLabel', DxChartLabel);
      app.component('DxChartLegend', DxChartLegend);
      app.component('DxChartLoadingIndicator', DxChartLoadingIndicator);
      app.component('DxChartPoint', DxChartPoint);
      app.component('DxChartSeries', DxChartSeries);
      app.component('DxChartSize', DxChartSize);
      app.component('DxChartTooltip', DxChartTooltip);

      app.component('DxGridColumn', DxGridColumn);
      app.component('DxDataGrid', DxDataGrid);
      app.component('DxGridEditing', DxGridEditing);
      app.component('DxGridFilterRow', DxGridFilterRow);
      app.component('DxGridGroupPanel', DxGridGroupPanel);
      app.component('DxGridGrouping', DxGridGrouping);
      app.component('DxGridItem', DxGridItem);
      app.component('DxGridLookup', DxGridLookup);
      app.component('DxGridMasterDetail', DxGridMasterDetail);
      app.component('DxGridPager', DxGridPager);
      app.component('DxGridPaging', DxGridPaging);
      app.component('DxGridSorting', DxGridSorting);
      app.component('DxGridToolbar', DxGridToolbar);

      app.component('DxEmailRule', DxEmailRule);
      app.component('DxPatternRule', DxPatternRule);
      app.component('DxRangeRule', DxRangeRule);
      app.component('DxRequiredRule', DxRequiredRule);
      app.component('DxStringLengthRule', DxStringLengthRule);
      app.component('DxValidator', DxValidator);
      app.component('DxValidationGroup', DxValidationGroup);
   },
};
