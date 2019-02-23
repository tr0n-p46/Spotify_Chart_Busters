import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import NotFound from '@/components/error-pages/NotFound'
import Chartbusters from '@/components/chartbusters/chartbusters.component'
import ChartbusterDetails from '@/components/chartbusters/chartbuster.details'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/chartbusters',
      name: 'Chartbusters',
      component: Chartbusters
    },
    {
      path: '/chartbusters/:id',
      name: 'ChartbusterDetails',
      component: ChartbusterDetails
    },
    {
      path: '*',
      name: 'NotFound',
      component: NotFound
    }
  ]
})
