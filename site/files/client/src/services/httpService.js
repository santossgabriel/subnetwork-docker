import axios from 'axios'

import storageService from './storageService'
import { loaderHandler } from '../handlers/loader-handler'

const getToken = () => `Bearer ${(storageService.getUser() || {}).token || ''}`

const sendRequest = (method, url, headers, data) => {
  loaderHandler.requestStarted()
  return axios({
    method: method,
    headers: headers,
    url: url,
    data: data
  }).then(res => {
    loaderHandler.requestEnded()
    return res.data
  })
    .catch(err => {
      loaderHandler.requestEnded()
      throw err.response.data
    })
}

const getHeaders = () => ({ Authorization: getToken() })

export default {
  getToken,
  getNotAuthenticated: url => sendRequest('get', `/api${url}`),
  postNotAuthenticated: (url, body) => sendRequest('post', `/api${url}`, null, body),
  get: url => sendRequest('get', `/api${url}`, getHeaders()),
  post: (url, body) => sendRequest('post', `/api${url}`, getHeaders(), body),
  put: (url, body) => sendRequest('put', `/api${url}`, getHeaders(), body),
  delete: (url, body) => sendRequest('delete', `/api${url}`, getHeaders(), body)
}