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

    public void Add(Simulation simulation)
    {
      _repository.Add(simulation);
    }

    public IEnumerable<Simulation> GetAll()
    {
      return _repository.GetAll();
    }
  }
}