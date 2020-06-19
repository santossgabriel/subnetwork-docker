import { combineReducers } from 'redux'
import { bannerGrabbingReducer } from './banner-grabbing.reducer'
import { networkSweepingReducer } from './network-sweeping.reducer'
import { toastReducer } from './toast.reducer'

export default combineReducers({
    bannerGrabbingState: bannerGrabbingReducer,
    networkSweepingState: networkSweepingReducer,
    toastState: toastReducer
})