import httpService from './httpService'

const get = () => httpService.get('/history')

export default {
  get
}