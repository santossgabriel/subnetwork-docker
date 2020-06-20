import { Home, Contact, Simulation } from '../scene'

export const ROUTES = [
  { title: 'Home', route: '/', exact: true, component: Home },
  { title: 'Contact', route: '/contact', component: Contact },
  { title: 'Simulation', route: '/simulation', component: Simulation },
]

export const toastTypes = {
  ERROR: 0,
  SUCCESS: 1
}

export const UserRoles = {
  Client: 0,
  Approver: 1
}