import { compose, createStore } from 'redux'
import Reducers from './reducers'
import { loaderHandler } from '../handlers/loader-handler'

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose

const store = createStore(
    Reducers,
    composeEnhancers()
)

loaderHandler.init(store.dispatch)

export default store