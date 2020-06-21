import axios from 'axios'

import storageService from './storageService'
import { requestHandler } from '../handlers/request-handler'

const getToken = () => `Bearer ${(storageService.getUser() || {}).token || ''}`

const sendRequest = (method, url, headers, data) => {
  requestHandler.requestStarted()
  return axios({
    method: method,
    headers: headers,
    url: url,
    data: data
  }).then(res => {
    requestHandler.requestEnded()
    return res.data
  })
    .catch(err => {
      requestHandler.requestEnded()
      const errorMessage = (err.response.data || {}).error
      if (errorMessage)
        requestHandler.showError(errorMessage)
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