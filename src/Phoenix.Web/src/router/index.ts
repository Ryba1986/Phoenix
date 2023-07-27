import { Router, createRouter, createWebHistory } from "vue-router";
import { routerRoutes } from "../config";

import Dashboard from "../views/Dashboard.vue";
import { authStore } from "../stores/authStore";

const router: Router = createRouter({
   history: createWebHistory(),
   routes: [
      {
         path: routerRoutes.default,
         redirect: routerRoutes.dashboard,
      },
      {
         path: routerRoutes.dashboard,
         component: Dashboard,
      },
      {
         path: "/:pathMatch(.*)",
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
