import { App, Plugin } from "vue";

import { DxButton } from "devextreme-vue/button";
import { DxDateBox } from "devextreme-vue/date-box";
import { DxForm } from "devextreme-vue/form";
import { DxLoadPanel } from "devextreme-vue/load-panel";
import { DxSelectBox } from "devextreme-vue/select-box";
import { DxTextBox } from "devextreme-vue/text-box";

import { DxValidationGroup } from "devextreme-vue/validation-group";
import { DxEmailRule, DxPatternRule, DxRangeRule, DxStringLengthRule, DxValidator } from "devextreme-vue/validator";

import Card from "../components/Card.vue";
import LoadPanel from "../components/LoadPanel.vue";
import NavBar from "../components/NavBar.vue";

export const componentPlugin: Plugin = {
   install(app: App<Element>): void {
      app.component("DxButton", DxButton);
      app.component("DxDateBox", DxDateBox);
      app.component("DxForm", DxForm);
      app.component("DxLoadPanel", DxLoadPanel);
      app.component("DxSelectBox", DxSelectBox);
      app.component("DxTextBox", DxTextBox);

      app.component("DxEmailRule", DxEmailRule);
      app.component("DxPatternRule", DxPatternRule);
      app.component("DxRangeRule", DxRangeRule);
      app.component("DxStringLengthRule", DxStringLengthRule);
      app.component("DxValidator", DxValidator);
      app.component("DxValidationGroup", DxValidationGroup);

      app.component("Card", Card);
      app.component("LoadPanel", LoadPanel);
      app.component("NavBar", NavBar);
   },
};
