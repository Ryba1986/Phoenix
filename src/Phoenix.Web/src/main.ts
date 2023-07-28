import { createApp } from "vue";
import { createPinia } from "pinia";
import App from "./App.vue";
import { i18n } from "./languages";
import { componentPlugin } from "./plugins/componentPlugin";
import router from "./router";

import "bootstrap/dist/css/bootstrap.min.css";
import "devextreme/dist/css/dx.material.teal.light.compact.css";
import "./styles/main.scss";

createApp(App).use(router).use(createPinia()).use(componentPlugin).use(i18n).mount("#app");
