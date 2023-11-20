import { Routes } from '../models/routers/routes';

export const apiRequestContentType: string = 'application/json';
export const apiTokenEmptyValue: string = '';
export const apiTokenName: string = 'ApiToken';
export const apiTokenRefreshInterval: number = 60_000;
export const apiUrlBase: string = '/apiweb/';

export const chartPaletteName: string = 'Material';

export const dashboardLocationIdName: string = 'DashboardLocationId';
export const dashboardRefreshInterval: number = 60_000;

export const dateFormat: string = 'yyyy-MM-dd';
export const dateTimeFormat: string = 'yyyy-MM-dd HH:mm:ss';
export const dateMonthDayTimeFormat: string = 'MM-dd HH:mm';
export const dateTimeShortFormat: string = 'yyyy-MM-dd HH:mm';

export const loadPanelDelay: number = 200;

export const routerRoutes: Routes = {
   default: '/',
   anonymous: ['/signin'],
   client: '/client',
   dashboard: '/dashboard',
   device: '/device',
   location: '/location',
   report: '/report',
   role: '/role',
   rolePermission: '/rolepermission',
   signIn: '/signin',
   signOut: '/signout',
   user: '/user',
};

export const toastDisplayTime: number = 3_000;
