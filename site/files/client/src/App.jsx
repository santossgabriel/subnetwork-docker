import React from 'react'
import { Provider } from 'react-redux'
import { HashRouter, Route } from 'react-router-dom'
import './App.css'
import { Sidebar, Toast, Toolbar, Header } from './components'
import { AppContainer, BaseContainer, CoreAppContainer } from './components/styles'
import Store from './store'
import { ROUTES } from './utils'

export default function App() {
  return (
    <Provider store={Store}>
      <AppContainer>
        <HashRouter>
          <Header />
          <div class="root-card">
            <BaseContainer>
              {ROUTES.map((r, i) => <Route key={i + ''} path={r.route} exact={r.exact} component={r.component} />)}
            </BaseContainer>
            <Toast />
          </div>
        </HashRouter>
      </AppContainer>
    </Provider>
  )
}