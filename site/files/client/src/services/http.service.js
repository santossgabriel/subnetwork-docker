import axios from 'axios'

import storageService from './storage.service'
import { requestMiddleware } from '../middlewares'

const getToken = () => `Bearer ${(storageService.getUser() || {}).token || ''}`

const sendRequest = (method, url, headers, data) => {
  requestMiddleware.requestStarted()
  return axios({
    method: method,
    headers: headers,
    url: url,
    data: data
  }).then(res => {
    requestMiddleware.requestEnded()
    const message = (res.data || {}).message
    if (message)
      requestMiddleware.showSuccess(message)
    return res.data
  })
    .catch(err => {
      requestMiddleware.requestEnded()
      const errorMessage = (err.response.data || {}).error
      if (errorMessage)
        requestMiddleware.showError(errorMessage)
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