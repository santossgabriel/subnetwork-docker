import httpService from './httpService'
const get = () => httpService.get('/comment')
const add = description => httpService.post('/comment', { description })
const remove = id => httpService.delete(`/comment/${id}`)

export default {
  get,
  add,
  remove
}