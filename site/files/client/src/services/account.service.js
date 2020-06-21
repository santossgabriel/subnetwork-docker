import httpService from './http.service'

const login = (email, password) => httpService.postNotAuthenticated('/account/login', { email, password })

const passwordReset = email => httpService.postNotAuthenticated('/account/password/reset', { email })

const logout = () => httpService.get('/account/logout')

export default {
  login,
  logout,
  passwordReset
}