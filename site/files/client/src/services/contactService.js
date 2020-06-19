import httpService from './httpService'

const send = contact => httpService.post('/contact', contact)

export default {
  send
}