import { App, Plugin } from 'vue';

import Card from '../components/Card.vue';
import DataGrid from '../components/DataGrid.vue';
import LoadPanel from '../components/LoadPanel.vue';
import NavBar from '../components/NavBar.vue';

export const componentPlugin: Plugin = {
   install(app: App<Element>): void {
      app.component('Card', Card);
      app.component('DataGrid', DataGrid);
      app.component('LoadPanel', LoadPanel);
      app.component('NavBar', NavBar);
   },
};
