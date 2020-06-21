import { compose, createStore } from 'redux'
import Reducers from './reducers'
import { requestHandler } from '../handlers/request-handler'

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose

const store = createStore(
    Reducers,
    composeEnhancers()
)

requestHandler.init(store.dispatch)

export default store