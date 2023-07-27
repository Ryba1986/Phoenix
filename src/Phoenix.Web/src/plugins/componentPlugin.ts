import { App, Plugin } from "vue";

import { DxButton } from "devextreme-vue/button";
import { DxDateBox } from "devextreme-vue/date-box";
import { DxLoadPanel } from "devextreme-vue/load-panel";
import { DxSelectBox } from "devextreme-vue/select-box";
import { DxTextBox } from "devextreme-vue/text-box";

export const componentPlugin: Plugin = {
   install(app: App<Element>): void {
      app.component("DxButton", DxButton);
      app.component("DxDateBox", DxDateBox);
      app.component("DxLoadPanel", DxLoadPanel);
      app.component("DxSelectBox", DxSelectBox);
      app.component("DxTextBox", DxTextBox);
   },
};
