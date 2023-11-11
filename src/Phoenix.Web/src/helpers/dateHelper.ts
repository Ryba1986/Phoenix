import { format, parseISO } from 'date-fns';
import { dateFormat, dateTimeFormat, dateTimeShortFormat } from '../config';

export function getDateString(date: Date): string {
   return format(date, dateFormat);
}

export function getDateTimeString(date: Date): string {
   return format(date, dateTimeFormat);
}

export function getDateTimeShortString(date: Date): string {
   return format(date, dateTimeShortFormat);
}

export function isoToDate(date: string): Date {
   return parseISO(date);
}
