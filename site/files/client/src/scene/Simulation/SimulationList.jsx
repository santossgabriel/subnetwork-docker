import React, { useState, useEffect } from 'react'
import { useSelector } from 'react-redux'
import { Link } from 'react-router-dom'

import { UserRoles } from '../../utils'
import { simulationService } from '../../services'

export function SimulationList() {

  const [simulations, setSimulations] = useState([])

  const user = useSelector(state => state.appState.user)

  useEffect(() => refresh(), [])

  function refresh() {
    simulationService.getAll()
      .then(res => setSimulations(res))
      .catch(err => console.error(err))
  }

  function approve(id) {
    simulationService.approve(id)
      .then(() => refresh())
      .catch(err => console.error(err))
  }

  return (
    <div>
      {
        simulations.length ?
          <>
            {user.role === UserRoles.Approver ?
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
                    <tr key={`${i}`} style={{ backgroundColor: i % 2 !== 0 ? "#ccc" : "#fff" }}>
                      <td>{s.id}</td>
                      <td>{s.description}</td>
                      <td>{s.amountMoney}</td>
                      <td>{s.totalMoney}</td>
                      <td>{s.plots}</td>
                      <td><Link to={`/simulation-details/${s.id}`}>Detalhes</Link></td>
                      {
                        user.role === UserRoles.Approver && !s.approvedAt ?
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