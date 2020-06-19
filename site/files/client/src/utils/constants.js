import { Home, Contact } from '../scene'

export const ROUTES = [
  { title: 'Home', route: '/', exact: true, component: Home },
  { title: 'Contact', route: '/contact', component: Contact },
]

export const toastTypes = {
  ERROR: 0,
  SUCCESS: 1
}