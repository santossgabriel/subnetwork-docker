import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import { contactService, accountService } from '../../services'
import { toastSuccess, toastHide } from '../../store/actions'

export function Contact() {

  const [name, setName] = useState('')
  const [email, setEmail] = useState('')
  const [filePath, setFilePath] = useState('')

  const dispatch = useDispatch()

  function sendContact() {
    contactService.send({ name, email, filePath })
      .then(res => {
        dispatch(toastSuccess('Email enviado.'))
        setTimeout(() => dispatch(toastHide()), 2000)
      })
  }

  function upload(e) {
    const file = e.target.files[0]
    if (file)
      accountService.uploadDocument(file)
        .then(res => setFilePath(res.file))
  }

  return (
    <div>
      <h3 className="page-title">Contato</h3>
      <form className="form-contact">
        Nome: <input className="form-input lg" onChange={e => setName(e.target.value)} /><br />
        Email: <input className="form-input lg" onChange={e => setEmail(e.target.value)} /><br />
        Documento: <input type="file" onChange={e => upload(e)} /><br />
        <button type="button"
          disabled={!name || !email || !filePath}
          onClick={() => sendContact()}
          style={{ marginTop: '20px' }}
          className="btn">Enviar</button>
      </form>
    </div>
  )
}