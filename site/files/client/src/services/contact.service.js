import httpService from './http.service'

const send = contact => httpService.post('/contact', contact)

export default {
  send
}