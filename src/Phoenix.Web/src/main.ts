import { createApp } from "vue";
import { createPinia } from "pinia";
import PrimeVue from "primevue/config";
import App from "./App.vue";
import { i18n } from "./languages";

import "primevue/resources/themes/lara-light-teal/theme.css";
import "primevue/resources/primevue.css";
import "primeflex/primeflex.scss";
import "primeicons/primeicons.css";

createApp(App).use(createPinia()).use(PrimeVue).use(i18n).mount("#app");
