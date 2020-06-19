import { compose, createStore } from 'redux'
import Reducers from './reducers'

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose

const store = createStore(
    Reducers,
    composeEnhancers()
)

export default store