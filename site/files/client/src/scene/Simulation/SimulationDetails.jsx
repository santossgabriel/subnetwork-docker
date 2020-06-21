import React, { useState, useEffect } from 'react'

import { simulationService } from '../../services'

export function SimulationDetails({ match }) {

  const [simulation, setSimulation] = useState(null)
  const { id } = match.params

  useEffect(() => {
    simulationService.get(id)
      .then(res => setSimulation(res))
  }, [id])

  return (
    <div className="box-simulation-details">

      {simulation ?
        <>
          <h3 className="page-title">Detalhes da simulação.</h3>

          <div>
            Produto: <span className="label">{simulation.description}</span>
          </div>

          <div>
            Criado em: <span className="label">{simulation.createdAtFormatted}</span>
          </div>

          {simulation.ApprovedAt &&
            <div>
              Aprovado em: <span className="label">{simulation.approvedAtFormatted}</span>
            </div>
          }

          <div>
            Valor Solicitado: <span className="label">{simulation.amountMoney}</span>
          </div>

          <div>
            Valor Financiado: <span className="label">{simulation.totalMoney}</span>
          </div>

          <div>
            Quantidade de parcelas: <span className="label">{simulation.plots}</span>
          </div>

          {simulation.total > 0 &&
            <>
              <div>
                Parcelas:
              </div>
              <table className="simulation-table">
                <thead>
                  <tr>
                    <th>Número</th>
                    <th>Valor</th>
                    <th>Juros</th>
                    <th>Valor com Juros</th>
                  </tr>
                </thead>
                <tbody>
                  {simulation.installments.map((p, i) =>
                    <tr key={`${i}`} style={{ backgroundColor: i % 2 !== 0 ? "#ccc" : "#fff" }}>
                      <td>{p.number}</td>
                      <td>{p.costMoney}</td>
                      <td>{p.interestMoney}</td>
                      <td>{p.totalMoney}</td>
                    </tr>)
                  }
                </tbody>
              </table>
            </>
          }
        </>
        :
        <h4 className="page-title sm">Simulação não encontrada.</h4>
      }
    </div >
  )
}