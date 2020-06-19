import React, { useState } from 'react'

export function SimulationDetails() {

  const [simulation, setSimulation] = useState(null)

  return (
    <div className="box-simulation-details">

      {simulation ?
        <h4 class="page-title sm">Simulação não encontrada.</h4>
        :
        <>
          <h3 class="page-title">Detalhes da simulação.</h3>

          <div>
            Produto: <span class="label">{simulation.description}</span>
          </div>

          <div>
            Criado em: <span class="label">{simulation.createdAtFormatted}</span>
          </div>

          {simulation.ApprovedAt &&
            <div>
              Aprovado em: <span class="label">{simulation.approvedAtFormatted}</span>
            </div>
          }

          <div>
            Valor Solicitado: <span class="label">{simulation.amountMoney}</span>
          </div>

          <div>
            Valor Financiado: <span class="label">{simulation.totalMoney}</span>
          </div>

          <div>
            Quantidade de parcelas: <span class="label">{simulation.plots}</span>
          </div>

          {simulation.total > 0 &&
            <>
              <div>
                Parcelas:
              </div>
              <table class="simulation-table">
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
                    <tr style={{ backgroundColor: i % 2 != 0 ? "#ccc" : "#fff" }}>
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
      }
    </div >
  )
}