import { format, parseISO } from 'date-fns';
import { dateFormat, dateTimeFormat, dateTimeShortFormat } from '../config';

export function toDateString(date: Date): string {
   return format(date, dateFormat);
}

export function toDateTimeString(date: Date): string {
   return format(date, dateTimeFormat);
}

export function toDateTimeShortString(date: Date): string {
   return format(date, dateTimeShortFormat);
}

export function toDate(date: string): Date {
   return parseISO(date);
}
