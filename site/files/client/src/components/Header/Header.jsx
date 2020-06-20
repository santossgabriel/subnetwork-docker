import React, { useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { Link } from 'react-router-dom'

import { accountService } from '../../services'
import { userChanged } from '../../store/actions'

export function Header() {

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const dispatch = useDispatch()
  const user = useSelector(state => state.appState.user)

  function login() {
    accountService.login(email, password)
      .then(res => dispatch(userChanged(res)))
      .catch(err => console.log(err))
  }

  function logout() {
    accountService.logout()
      .then(() => dispatch(userChanged(null)))
      .catch(err => console.log(err))
  }

  return (
    <header className="toolbar">
      <div>
        <img className="logo" src="favicon.ico" />
        <Link className="app-title" to="/">Fake Bank</Link>
      </div>
      <div className="menu-toolbar">
        {user && <Link to="simulation">Simulador</Link>}
        <Link to="contact">Contato</Link>
      </div>

      {user ?
        <>
          <span className="logged-name">{user.name}</span>
          <a onClick={() => logout()} className="btn">Sair</a>
        </>
        :
        <form className="login-form">
          <input className="form-input" placeholder="Email" onChange={e => setEmail(e.target.value)} />
          <input className="form-input" type="password" placeholder="Senha" onChange={e => setPassword(e.target.value)} />
          <button type="button" className="btn" onClick={() => login()}>Entrar</button>
        </form>
      }
    </header>
  )
}