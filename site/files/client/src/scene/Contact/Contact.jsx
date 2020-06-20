import React, { useState } from 'react'
import { contactService } from '../../services'

export function Contact() {

  const [error, setError] = useState(false)
  const [name, setName] = useState('')
  const [email, setEmail] = useState('')
  const [message, setMessage] = useState('')

  function sendContact() {
    contactService.send({ name, email, message })
      .then(res => { })
      .catch(err => setError(true))
  }

  return (
    <div>
      <h3 className="page-title">Contato</h3>
      <form className="form-contact">
        Nome: <input className="form-input lg" onChange={e => setName(e.target.value)} /><br />
        Email: <input className="form-input lg" onChange={e => setEmail(e.target.value)} /><br />
        Mensagem: <textarea onChange={e => setMessage(e.target.value)} ></textarea><br />
        <button type="button"
          onClick={() => sendContact()}
          style={{ marginTop: '20px' }}
          className="btn">Enviar</button>
      </form>
      {error && <span className="error-message">Não foi possível enviar o email</span>}
    </div>
  )
}