import { format } from "date-fns";
import { dateFormat, dateTimeFormat, dateTimeShortFormat } from "../config";

export function getDateString(date: Date): string {
   return format(new Date(date), dateFormat);
}

export function getDateTimeString(date: Date): string {
   return format(new Date(date), dateTimeFormat);
}

export function getDateTimeShortString(date: Date): string {
   return format(new Date(date), dateTimeShortFormat);
}
