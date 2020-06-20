import { toastTypes } from '../../utils'
import { UserActionsTypes } from '../actions'
import { storageService } from '../../services'

const INITIAL_STATE = {
  user: storageService.getUser()
}

export const appReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case UserActionsTypes.USER_CHANGED:
      storageService.setUser(action.payload)
      return { ...state, user: action.payload }
    default:
      return state
  }
}