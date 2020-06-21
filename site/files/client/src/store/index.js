import { compose, createStore } from 'redux'
import Reducers from './reducers'
import { requestMiddleware } from '../middlewares'

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose

const store = createStore(
    Reducers,
    composeEnhancers()
)

requestMiddleware.init(store.dispatch)

export default store