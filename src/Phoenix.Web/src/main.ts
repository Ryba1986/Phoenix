import { createApp } from 'vue';
import { createPinia } from 'pinia';
import App from './App.vue';
import { i18n } from './languages';
import { componentPlugin } from './plugins/componentPlugin';
import { devextremePlugin } from './plugins/devextremePlugin';
import router from './router';

import 'bootstrap/dist/css/bootstrap.min.css';
import 'devextreme/dist/css/dx.material.teal.light.compact.css';
import '../src/styles/main.scss';

createApp(App).use(router).use(createPinia()).use(devextremePlugin).use(componentPlugin).use(i18n).mount('#app');
