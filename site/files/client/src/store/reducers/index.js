import { combineReducers } from 'redux'
import { toastReducer } from './toast.reducer'
import { appReducer } from './app.reducer'

export default combineReducers({
    appState: appReducer,
    toastState: toastReducer
})