import { CommandActionsTypes } from '../actions'

const INITIAL_STATE = {
  networkSweepingOutput: '',
  networkSweepingRunning: false,
}

export const networkSweepingReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case CommandActionsTypes.NETWORK_SWEEPING_START:
      return {
        networkSweepingOutput: action.payload,
        networkSweepingRunning: true
      }
    case CommandActionsTypes.NETWORK_SWEEPING_DATA:
      return {
        networkSweepingOutput: state.networkSweepingOutput + action.payload,
        networkSweepingRunning: true
      }
    case CommandActionsTypes.NETWORK_SWEEPING_END:
      return {
        networkSweepingOutput: state.networkSweepingOutput + action.payload,
        networkSweepingRunning: false
      }
    default:
      return state
  }
}