import { hideLoader, showLoader, toastError, toastHide, toastSuccess } from '../store/actions'

const middleware = (() => {
  const _self = {}

  let pending = 0

  let dispatch

  _self.init = d => {
    dispatch = d
  }

  _self.requestStarted = () => {
    pending++
    if (pending > 0)
      dispatch(showLoader())
  }

  _self.requestEnded = () => {
    pending--
    if (pending <= 0)
      setTimeout(() => dispatch(hideLoader()), 300)
  }

  _self.showError = error => {
    dispatch(toastError(error))
    setTimeout(() => dispatch(toastHide()), 2000)
  }

  _self.showSuccess = message => {
    dispatch(toastSuccess(message))
    setTimeout(() => dispatch(toastHide()), 2000)
  }

  return _self
})()

export const requestMiddleware = middleware