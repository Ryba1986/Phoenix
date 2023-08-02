import { createI18n } from "vue-i18n";
import { english } from "./english";
import { polish } from "./polish";

console.warn(navigator.language);

export const i18n = createI18n({
   legacy: false,
   locale: navigator.language,
   fallbackLocale: "en",
   messages: {
      en: english,
      pl: polish,
   },
});
