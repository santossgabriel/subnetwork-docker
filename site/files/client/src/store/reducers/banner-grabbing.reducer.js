import { CommandActionsTypes } from '../actions'

const INITIAL_STATE = {
  bannerGrabbingOutput: '',
  bannerGrabbingRunnig: false
}

export const bannerGrabbingReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case CommandActionsTypes.BANNER_GRABBING_START:
      return {
        bannerGrabbingOutput: action.payload,
        bannerGrabbingRunnig: true
      }
    case CommandActionsTypes.BANNER_GRABBING_DATA:
      return {
        bannerGrabbingOutput: state.bannerGrabbingOutput + action.payload,
        bannerGrabbingRunnig: true
      }
    case CommandActionsTypes.BANNER_GRABBING_END:
      return {
        bannerGrabbingOutput: state.bannerGrabbingOutput + action.payload,
        bannerGrabbingRunnig: false
      }
    default:
      return state
  }
}