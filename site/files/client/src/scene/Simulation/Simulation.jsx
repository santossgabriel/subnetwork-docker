import React, { useState } from 'react'

export function Simulation() {

  const [description, setDescription] = useState('')
  const [amount, setAmount] = useState('')
  const [plots, setPlost] = useState('')

  return (
    <div>
      <h3 className="page-title">Simule seu financiamento.</h3>

      <form asp-controller="Simulation" asp-action="Add" method="post" className="form-simulation">

        <span>Descrição da produto:</span>
        <input className="form-input" onChange={e => setDescription(e.target.value)} />
        <span asp-validation-for="Description" className="validation-error"></span>

        <span>Valor total:</span>
        <input className="form-input" onChange={e => setAmount(e.target.value)} />
        <span asp-validation-for="Amount" className="validation-error"></span>

        <span>Quantidade de parcelas:</span>
        <input class="form-input" onChange={e => setAmount(e.target.value)} />
        <span asp-validation-for="Plots" className="validation-error"></span>

        <div style={{ textAlign: 'center' }}>
          <button className="btn btn-simulation">Simular</button>
          <div style={{ marginTop: '5px', fontSize: '12px' }} >
            <a href="/Simulation/List">Ver Simulações</a>
          </div>
        </div>
      </form>
    </div>
  )
}