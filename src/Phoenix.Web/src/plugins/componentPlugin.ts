import { App, Plugin } from 'vue';

import Card from '../components/Card.vue';
import Chart from '../components/Chart.vue';
import DataGrid from '../components/DataGrid.vue';
import LoadPanel from '../components/LoadPanel.vue';
import NavBar from '../components/NavBar.vue';

import Climatix from '../components/plcs/Climatix.vue';
import Kamstrup from '../components/plcs/Kamstrup.vue';
import Rvd145 from '../components/plcs/Rvd145.vue';

export const componentPlugin: Plugin = {
   install(app: App<Element>): void {
      app.component('Card', Card);
      app.component('Chart', Chart);
      app.component('DataGrid', DataGrid);
      app.component('LoadPanel', LoadPanel);
      app.component('NavBar', NavBar);

      app.component('Climatix', Climatix);
      app.component('Kamstrup', Kamstrup);
      app.component('Rvd145', Rvd145);
   },
};
