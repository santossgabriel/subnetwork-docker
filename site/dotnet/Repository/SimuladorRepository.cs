using System;
using System.Collections.Generic;
using Site.Config;
using Site.Models;

namespace Site.Repository
{
  public class SimulationRepository : BaseRepository<Simulation>
  {
    public SimulationRepository(AppConfig config) : base(config) { }

    public void Add(Simulation simulation) => Execute("", simulation);

    public IEnumerable<Simulation> GetAll() => throw new NotImplementedException();

    public Simulation GetById(int id) => throw new NotImplementedException();

    public IEnumerable<Simulation> GetByUserId(int userId) => Query("", new { UserId = userId });
  }
}