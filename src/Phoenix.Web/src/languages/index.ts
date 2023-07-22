import { createI18n } from "vue-i18n";
import { english } from "./english";

export const i18n = createI18n({
   legacy: false,
   locale: "en-US",
   fallbackLocale: "en-US",
   messages: {
      "en-US": english,
   },
});
