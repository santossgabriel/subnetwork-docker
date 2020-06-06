using System;
using System.Collections.Generic;
using Site.Models;
using Site.Repository;

namespace Site.Services
{
  public class SimulationService
  {
    private SimulationRepository _repository;

    public SimulationService(SimulationRepository repository)
    {
      _repository = repository;
    }

    public long Add(SimulationModel simulation)
    {
      return _repository.Add(simulation);
    }

    public IEnumerable<SimulationModel> GetByUser(long userId)
    {
      var list = _repository.GetByUser(userId);
      foreach (var s in list)
        FillInstallments(s);
      return list;
    }

    public IEnumerable<SimulationModel> GetAll()
    {
      var list = _repository.GetAll();
      foreach (var s in list)
        FillInstallments(s);
      return list;
    }

    public SimulationModel Get(long id, long userId)
    {
      var simulation = _repository.GetById(id);

      if (simulation == null || userId == 0)
        return null;

      FillInstallments(simulation);

      return simulation;
    }

    public void Approve(long id) => _repository.Approve(id);

    private void FillInstallments(SimulationModel simulation)
    {
      simulation.Installments = new List<SimulationInstallmentModel>();
      var installmentCost = simulation.Amount / simulation.Plots;

      for (int i = 1; i <= simulation.Plots; i++)
      {
        var item = new SimulationInstallmentModel();
        item.Number = i;
        item.Cost = Math.Round(installmentCost, 2);
        item.Interest = Math.Round(installmentCost * 0.07M, 2);
        simulation.Installments.Add(item);
      }
    }
  }
}