import React, { useState } from 'react'
export function Contact() {

  const [error, setError] = useState(false)

  return (
    <div>
      <h3 className="page-title">Contato</h3>
      <form className="form-contact" asp-action="SendContact">
        Nome: <input className="form-input lg" asp-for="Name" /><br />
        Email: <input className="form-input lg" asp-for="Email" /><br />
        Mensagem: <textarea asp-for="Message"></textarea><br />
        <button style={{ marginTop: '20px' }} className="btn">Enviar</button>
      </form>
      {error && <span className="error-message">Não foi possível enviar o email</span>}
    </div>
  )
}