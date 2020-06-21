import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import { contactService } from '../../services'
import { toastSuccess, toastHide } from '../../store/actions'

export function Contact() {

  const [name, setName] = useState('')
  const [email, setEmail] = useState('')
  const [message, setMessage] = useState('')

  const dispatch = useDispatch()

  function sendContact() {
    contactService.send({ name, email, message })
      .then(res => {
        dispatch(toastSuccess('Email enviado.'))
        setTimeout(() => dispatch(toastHide()), 2000)
      })
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
    </div>
  )
}