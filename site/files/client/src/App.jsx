import React from 'react'
import { Provider } from 'react-redux'
import { HashRouter, Route } from 'react-router-dom'
import './App.css'
import { Toast, Header } from './components'
import { Contact, Simulation, Home, SimulationDetails, SimulationList } from './scene'
import { AppContainer, BaseContainer } from './components/styles'
import Store from './store'

export default function App() {
  return (
    <Provider store={Store}>
      <AppContainer>
        <HashRouter>
          <Header />
          <div className="root-card">
            <BaseContainer>
              <Route path="/" exact={true} component={Home} />
              <Route path="/contact" component={Contact} />
              <Route path="/simulation" component={Simulation} />
              <Route path="/simulation-list" component={SimulationList} />
              <Route path="/simulation-details/:id" component={SimulationDetails} />
            </BaseContainer>
            <Toast />
          </div>
        </HashRouter>
      </AppContainer>
    </Provider>
  )
}