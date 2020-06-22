import React, { useState } from 'react'
import { useSelector } from 'react-redux'

import { accountService } from '../../services'

export function AccountData() {
  const user = useSelector(state => state.appState.user)
  const [name, setName] = useState((user || {}).name)
  const [document, setDocument] = useState('')

  function upload(e) {
    const file = e.target.files[0]
    if (file)
      accountService.uploadDocument(file)
        .then(res => setDocument(res.file))
  }

  function save() {
    accountService.save({ name, document })
  }

  if (!user)
    return <div></div>

  return (
    <div>
      <h3 className="page-title">Informações da Conta</h3>
      <br />
      Email: <span>{user.email}</span>
      <br />
      <br />
      <span>Nome:</span>
      <input defaultValue={user.name} className="form-input" onChange={e => setName(e.target.value)} />
      <br />
      <br />
      Documento Atual: <span>{user.document}</span>
      <br />
      <br />
        Documento: <input type="file" onChange={e => upload(e)} /><br />
      <button type="button"
        disabled={!name || !document}
        onClick={() => save()}
        style={{ marginTop: '20px' }}
        className="btn">Salvar</button>
    </div >
  )
}