import { Language } from "../models/languages/language";

export const english: Language = {
   components: {},
   requests: {
      default: "An error occurred while executing the operation.",
      fileNameNotExists: "File name not exists.",
      forbidden: "You are not authorized to perform this operation.",
      unauthorized: "You are not authorized.",
      userNotFound: "User not found.",
   },
   views: {},
};
