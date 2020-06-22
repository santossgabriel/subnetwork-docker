using System;
using System.Collections.Generic;
using Site.Models;
using Site.Repository;

namespace Site.Services
{
  public class SimulationService
  {
    private SimulationRepository _simulationRepository;

    private UserRepository _userRepository;

    public SimulationService(SimulationRepository simulationRepository, UserRepository userRepository)
    {
      _simulationRepository = simulationRepository;
      _userRepository = userRepository;
    }

    public long Add(SimulationModel simulation)
    {
      return _simulationRepository.Add(simulation);
    }

    public IEnumerable<SimulationModel> GetByUser(long userId)
    {
      var list = _simulationRepository.GetByUser(userId);
      foreach (var s in list)
        FillProps(s);
      return list;
    }

    public IEnumerable<SimulationModel> GetAll()
    {
      var list = _simulationRepository.GetAll();
      foreach (var s in list)
        FillProps(s);
      return list;
    }

    public SimulationModel Get(long id, long userId)
    {
      var simulation = _simulationRepository.GetById(id);

      if (simulation == null || userId == 0)
        return null;

      FillProps(simulation);

      return simulation;
    }

    public bool Approve(long id)
    {
      var simulation = _simulationRepository.GetById(id);
      if (simulation == null || simulation.ApprovedAt != null)
        return false;
      _simulationRepository.Approve(id);
      return true;
    }

    private void FillProps(SimulationModel simulation)
    {
      simulation.Installments = new List<SimulationInstallmentModel>();
      simulation.User = _userRepository.GetById(simulation.UserId).WithoutPassword();
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