import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { useSession } from '../composables/session.js'

const { isLogged } = useSession()

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/profile',
      name: 'profile',
      component: () => import('../views/ProfileView.vue')
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue')
    },
    {
      path: '/profile/end',
      name: 'ProfileEnd',
      component: () => import('../views/ProfileEndView.vue')
    }
  ]
})

router.beforeEach((to, _, next) => {
  const publicPages = ['/', '/about']
  const authRequired = !publicPages.includes(to.path)

  if (authRequired && !isLogged.value)
    next('/')
  else
    next()
})

export default router
