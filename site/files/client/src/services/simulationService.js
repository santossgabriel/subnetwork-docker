import httpService from './httpService'

const get = id => httpService.get(`/simulation/${id}`)
const getAll = () => httpService.get('/simulation')
const create = simulation => httpService.post('/simulation', simulation)
const approve = id => httpService.put(`/simulation/approve/${id}`)

export default {
  get,
  getAll,
  create,
  approve
}