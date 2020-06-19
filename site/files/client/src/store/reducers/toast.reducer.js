import { toastTypes } from '../../utils'
import { ToastActionsTypes } from '../actions'

const INITIAL_STATE = {
  message: '',
  type: ''
}

export const toastReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case ToastActionsTypes.SUCCESS:
      return { message: action.payload, type: toastTypes.SUCCESS }
    case ToastActionsTypes.ERROR:
      console.log(action.payload)
      return { message: action.payload, type: toastTypes.ERROR }
    case ToastActionsTypes.HIDE:
      return { ...state, message: '' }
    default:
      return state
  }
}