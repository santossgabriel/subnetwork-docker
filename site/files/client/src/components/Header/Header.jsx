import React, { useState } from 'react'
import { Link } from 'react-router-dom'

import { accountService } from '../../services'

export function Header() {

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [user, setUser] = useState(null)

  function login() {
    accountService.login(email, password)
      .then(res => setUser(res))
      .catch(err => console.log(err))
  }

  function logout() {
    accountService.logout()
      .then(res => setUser(null))
      .catch(err => console.log(err))
  }

  return (
    <header className="toolbar">
      <div>
        <img className="logo" src="favicon.ico" />
        <Link className="app-title" to="/">Fake Bank</Link>
      </div>
      <div className="menu-toolbar">
        {user && <Link to="simulator">Simulador</Link>}
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