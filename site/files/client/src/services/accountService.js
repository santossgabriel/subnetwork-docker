import httpService from './httpService'

const login = (email, password) => httpService.postNotAuthenticated('/account/login', { email, password })

const logout = () => httpService.get('/account/logout')

export default {
  login,
  logout
}