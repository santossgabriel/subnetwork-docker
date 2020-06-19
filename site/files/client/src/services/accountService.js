import httpService from './httpService'

const login = (name, password) => httpService.postNotAuthenticated('/token', { name, password })

export default {
  login
}