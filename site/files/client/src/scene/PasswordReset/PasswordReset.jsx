import React, { useState } from 'react'

import { accountService } from '../../services'

export function PasswordReset() {

  const [email, setEmail] = useState('')

  function send() {
    accountService.passwordReset(email)
  }

  return (
    <div>
      <h3 className="page-title">Recuperação de senha</h3>
      <br />
      Email: <input className="form-input lg" onChange={e => setEmail(e.target.value)} />
      <button type="button"
        disabled={!email}
        onClick={() => send()}
        style={{ marginTop: '20px', marginLeft: '30px' }}
        className="btn">Enviar</button>
    </div>
  )
}