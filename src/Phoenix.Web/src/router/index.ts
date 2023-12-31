import { Router, createRouter, createWebHistory } from 'vue-router';
import { routerRoutes } from '../config';
import { authStore } from '../stores/authStore';

import Client from '../views/Client.vue';
import Dashboard from '../views/Dashboard.vue';
import Device from '../views/Device.vue';
import Location from '../views/Location.vue';
import Report from '../views/Report.vue';
import Role from '../views/Role.vue';
import RolePermission from '../views/RolePermission.vue';
import SignIn from '../views/SignIn.vue';
import SignOut from '../views/SignOut.vue';
import User from '../views/User.vue';

const router: Router = createRouter({
   history: createWebHistory(),
   routes: [
      {
         path: routerRoutes.default,
         redirect: routerRoutes.dashboard,
      },
      {
         path: routerRoutes.client,
         component: Client,
      },
      {
         path: routerRoutes.dashboard,
         component: Dashboard,
      },
      {
         path: routerRoutes.device,
         component: Device,
      },
      {
         path: routerRoutes.location,
         component: Location,
      },
      {
         path: routerRoutes.report,
         component: Report,
      },
      {
         path: routerRoutes.role,
         component: Role,
      },
      {
         path: routerRoutes.rolePermission,
         component: RolePermission,
      },
      {
         path: routerRoutes.signIn,
         component: SignIn,
      },
      {
         path: routerRoutes.signOut,
         component: SignOut,
      },
      {
         path: routerRoutes.user,
         component: User,
      },
      {
         path: '/:pathMatch(.*)',
         redirect: routerRoutes.default,
      },
   ],
});

router.beforeEach((to, _from, next) => {
   const store = authStore();
   const authRequired: boolean = !routerRoutes.anonymous.includes(to.path);

   if (authRequired && !store.isLogged) {
      return next(routerRoutes.signIn);
   }
   if (!authRequired && store.isLogged) {
      return next(routerRoutes.default);
   }

   next();
});

export default router;
