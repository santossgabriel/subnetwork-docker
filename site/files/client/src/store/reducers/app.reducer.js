import { AppActionsTypes } from '../actions'
import { storageService } from '../../services'

const INITIAL_STATE = {
  user: storageService.getUser(),
  loading: false
}

export const appReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case AppActionsTypes.USER_CHANGED:
      storageService.setUser(action.payload)
      return { ...state, user: action.payload }
    case AppActionsTypes.LOADER_CHANGED:
      return { ...state, loading: action.payload }
    default:
      return state
  }
}