import { Router, createRouter, createWebHistory } from "vue-router";
import { routerRoutes } from "../config";
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
         component: () => import("../views/Dashboard.vue"),
      },
      {
         path: routerRoutes.report,
         component: () => import("../views/Report.vue"),
      },
      {
         path: routerRoutes.location,
         component: () => import("../views/Location.vue"),
      },
      {
         path: routerRoutes.signIn,
         component: () => import("../views/SignIn.vue"),
      },
      {
         path: routerRoutes.signOut,
         component: () => import("../views/SignOut.vue"),
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
