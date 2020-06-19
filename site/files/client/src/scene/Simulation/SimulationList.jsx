import React from 'react'

import { Link } from 'react-router-dom'

const isAdmin = false

const simulations = []

export function SimulationList() {

  function approve(id) {
    console.log(id)
  }

  return (
    <div>
      {
        simulations.length ?
          <>
            {isAdmin ?
              <h3 className="page-title">Simulações</h3>
              :
              <h3 className="page-title">Simulações realizadas.</h3>
            }
            <table style={{ marginTop: '50px' }} className="simulation-table">
              <thead>
                <tr>
                  <th>Id</th>
                  <th>Produto</th>
                  <th>Valor Solicitado</th>
                  <th>Valor Financiado</th>
                  <th>Parcelas</th>
                  <th></th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                {
                  simulations.map((s, i) =>
                    <tr style={{ backgroundColor: i % 2 != 0 ? "#ccc" : "#fff" }}>
                      <td>{s.id}</td>
                      <td>{s.description}</td>
                      <td>{s.amountMoney}</td>
                      <td>{s.totalMoney}</td>
                      <td>{s.plots}</td>
                      <td><Link to={`/simulation-details/${s.id}`}>Detalhes</Link></td>
                      {
                        isAdmin && !s.ApprovedAt ?
                          <td>
                            <button onClick={() => approve(s.id)} className="btn">Aprovar</button>
                          </td>
                          :
                          <td></td>
                      }
                    </tr>
                  )
                }
              </tbody>
            </table>
          </>
          :
          <h4 className="page-title sm">Simulação não encontrada.</h4>
      }
    </div >
  )
}