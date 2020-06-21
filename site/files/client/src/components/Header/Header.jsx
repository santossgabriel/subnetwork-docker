import React, { useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { Link, useHistory } from 'react-router-dom'

import { accountService } from '../../services'
import { userChanged } from '../../store/actions'
import { UserRoles } from '../../utils'

export function Header() {

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const dispatch = useDispatch()
  const user = useSelector(state => state.appState.user)

  const history = useHistory()

  function login() {
    accountService.login(email, password)
      .then(res => dispatch(userChanged(res)))
  }

  function logout() {
    accountService.logout()
      .then(() => {
        dispatch(userChanged(null))
        history.push('/')
      })
  }

  return (
    <header className="toolbar">
      <div>
        <img alt="icon" className="logo" src="favicon.ico" />
        <Link className="app-title" to="/">Fake Bank</Link>
      </div>
      <div className="menu-toolbar">
        {user && user.role === UserRoles.Client && <Link to="/simulation">Simulador</Link>}
        {user && user.role === UserRoles.Approver && <Link to="/simulation-list">Simulações</Link>}
        <Link to="/contact">Contato</Link>
      </div>

      {user ?
        <>
          <span className="logged-name">{user.name}</span>
          <button type="button" onClick={() => logout()} className="btn">Sair</button>
        </>
        :
        <form className="login-form">
          <input className="form-input" placeholder="Email" onChange={e => setEmail(e.target.value)} />
          <input className="form-input" type="password" placeholder="Senha" onChange={e => setPassword(e.target.value)} />
          <button disabled={!email || !password} type="button" className="btn" onClick={() => login()}>Entrar</button>
          <br />
          <Link to="/password-reset" style={{ fontSize: 12 }}>Esqueci a senha</Link>
        </form>
      }
    </header>
  )
}