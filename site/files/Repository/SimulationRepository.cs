using System;
using System.Collections.Generic;
using Site.Config;
using Site.Models;

namespace Site.Repository
{
  public class SimulationRepository : BaseRepository<SimulationModel>
  {
    public SimulationRepository(AppConfig config) : base(config) { }

    public long Add(SimulationModel simulation)
    {
      var query = "INSERT INTO \"SIMULATION\" (EMAIL, DESCRIPTION, PLOTS, AMOUNT, USER_ID) VALUES (@Email, @Description, @Plots, @Amount, @UserId)";
      Execute(query, simulation);
      return CurrentId(simulation);
    }

    public SimulationModel GetById(long id)
    {
      var query = "SELECT ID, EMAIL, DESCRIPTION, PLOTS, AMOUNT FROM \"SIMULATION\" WHERE ID = @Id";
      return FirstOrDefault(query, new { Id = id });
    }

    public IEnumerable<SimulationModel> GetByUser(int userId)
    {
      var query = "SELECT ID, EMAIL, DESCRIPTION, PLOTS, AMOUNT FROM \"SIMULATION\" WHERE USER_ID = @UserId";
      return Query(query, new { UserId = userId });
    }
  }
}