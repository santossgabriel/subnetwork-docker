import React from 'react'

import { Link } from 'react-router-dom'

export function Home() {
  return (
    <div>
      <h1 class="page-title">Bem vindo!</h1>

      <div style={{ marginTop: '20px', maxWidth: '500px' }}>
        Entre em <Link to="Contact">Contato</Link> conosco solicitando seu cadastro informando seus dados e aproveite nosso crédito financiado.
    </div>
    </div>
  )
}