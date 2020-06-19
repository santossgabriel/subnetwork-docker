import React from 'react'

import { Link } from 'react-router-dom'

const authenticated = true
const userName = 'teste'

export function Header() {
  return (
    <header className="toolbar">
      <div>
        <img className="logo" src="favicon.ico" />
        <Link className="app-title" to="/">Fake Bank</Link>
      </div>
      <div class="menu-toolbar">
        {authenticated && <Link to="simulator">Simulador</Link>}
        <Link to="contact">Contato</Link>
      </div>

      {authenticated ?
        <>
          <span class="logged-name">{userName}</span>
          <a class="btn">Sair</a>
        </>
        :
        <form className="login-form">
          <input className="form-input" name="email" placeholder="Email" />
          <input className="form-input" type="password" name="password" placeholder="Senha" />
          <button className="btn">Entrar</button>
        </form>
      }
    </header>
  )
}