using System;
using System.Collections.Generic;
using Site.Models;
using Site.Services;

namespace Site.Repository
{
  public class SimulationRepository : BaseRepository<Simulation>
  {
    public SimulationRepository(ConfigService conn) : base(conn) { }

    public void Add(Simulation simulation) => Execute("", simulation);

    public IEnumerable<Simulation> GetAll() => throw new NotImplementedException();

    public Simulation GetById(int id) => throw new NotImplementedException();

    public IEnumerable<Simulation> GetByUserId(int userId) => Query("", new { UserId = userId });
  }
}