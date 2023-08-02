import { createI18n } from "vue-i18n";
import { en } from "./en";
import { pl } from "./pl";

export const i18n = createI18n({
   legacy: false,
   locale: navigator.language,
   fallbackLocale: "en",
   messages: {
      en: en,
      pl: pl,
   },
});
