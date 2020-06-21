import { hideLoader, showLoader } from '../store/actions'

const handler = (() => {
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

  return _self
})()

export const loaderHandler = handler