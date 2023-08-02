import { createI18n } from "vue-i18n";
import { english } from "./english";
import { polish } from "./polish";

export const i18n = createI18n({
   legacy: false,
   locale: "en-US",
   fallbackLocale: "en-US",
   messages: {
      "en-US": english,
      "pl-PL": polish,
   },
});
