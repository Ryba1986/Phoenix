import { createApp } from "vue";
import { createPinia } from "pinia";
import PrimeVue from "primevue/config";
import App from "./App.vue";
import { i18n } from "./languages";
import { componentPlugin } from "./plugins/componentPlugin";
import router from "./router";

import "primevue/resources/themes/lara-light-teal/theme.css";
import "primevue/resources/primevue.css";
import "primeflex/primeflex.scss";
import "primeicons/primeicons.css";
import "./styles/main.scss";

createApp(App).use(router).use(createPinia()).use(PrimeVue).use(componentPlugin).use(i18n).mount("#app");
