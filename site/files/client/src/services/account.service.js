import httpService from './http.service'

const login = (email, password) => httpService.postNotAuthenticated('/account/login', { email, password })

const passwordReset = email => httpService.postNotAuthenticated('/account/password/reset', { email })

const logout = () => httpService.get('/account/logout')

const uploadDocument = file => {
  const data = new FormData()
  data.append('file', file)
  return httpService.postNotAuthenticated('/account/upload/document', data)
}

export default {
  login,
  logout,
  passwordReset,
  uploadDocument
}