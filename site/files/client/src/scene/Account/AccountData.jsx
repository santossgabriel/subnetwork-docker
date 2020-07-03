import React, { useState } from 'react'
import { useSelector, useDispatch } from 'react-redux'

import { accountService } from '../../services'
import { userChanged } from '../../store/actions'

export function AccountData() {

  const user = useSelector(state => state.appState.user)

  const [name, setName] = useState((user || {}).name)
  const [document, setDocument] = useState('')

  const dispatch = useDispatch()

  function upload(e) {
    const file = e.target.files[0]
    if (file)
      accountService.uploadDocument(file)
        .then(res => setDocument(res.file))
  }

  function save() {
    accountService.save({ name, document })
      .then(res => dispatch(userChanged({ ...user, document, name })))
  }

  function download(fileName) {
    accountService.download(fileName).then(res => {
      const link = window.document.createElement('a')
      const blob = new Blob([new Uint8Array(res.bytes)], { mime: res.contentType })
      link.href = window.URL.createObjectURL(blob)
      link.download = fileName
      window.document.body.appendChild(link)
      link.click()
    })
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
      Documento Atual: <a style={{ cursor: 'pointer' }} onClick={() => download(user.document)}>{user.document}</a>
      <br />
      <br />
      Documento: <input type="file" onChange={e => upload(e)} /><br />
      <button type="button"
        disabled={!name || !document}
        onClick={() => save()}
        style={{ marginTop: '20px' }}
        className="btn">Atualizar</button>
    </div >
  )
}