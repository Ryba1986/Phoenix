import { addDays as fnsAddDays, format as fnsFormat, parseISO as fnsParseIso } from 'date-fns';
import { dateFormat, dateTimeFormat, dateTimeShortFormat } from '../config';

export function addDays(date: Date, amount: number): Date {
   return fnsAddDays(date, amount);
}

export function getDateString(date: Date): string {
   return fnsFormat(date, dateFormat);
}

export function getDateTimeString(date: Date): string {
   return fnsFormat(date, dateTimeFormat);
}

export function getDateTimeShortString(date: Date): string {
   return fnsFormat(date, dateTimeShortFormat);
}

export function isoToDate(date: string): Date {
   return fnsParseIso(date);
}
