import { Router, createRouter, createWebHistory } from "vue-router";
import { routerRoutes } from "../config";
import { authStore } from "../stores/authStore";

import Dashboard from "../views/Dashboard.vue";
import SignIn from "../views/SignIn.vue";
import SignOut from "../views/SignOut.vue";

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
         path: routerRoutes.signIn,
         component: SignIn,
      },
      {
         path: routerRoutes.signOut,
         component: SignOut,
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
