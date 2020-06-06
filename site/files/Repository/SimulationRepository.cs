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
      var query = "INSERT INTO \"SIMULATION\" (DESCRIPTION, PLOTS, AMOUNT, USER_ID, CREATED_AT) VALUES (@Description, @Plots, @Amount, @UserId, @CreatedAt)";
      simulation.CreatedAt = DateTime.Now;
      Execute(query, simulation);
      return CurrentId(simulation);
    }

    public SimulationModel GetById(long id)
    {
      var query = "SELECT ID, DESCRIPTION, PLOTS, AMOUNT, CREATED_AT AS CreatedAt, APPROVED_AT FROM \"SIMULATION\" WHERE ID = @Id";
      return FirstOrDefault(query, new { Id = id });
    }

    public IEnumerable<SimulationModel> GetByUser(long userId)
    {
      var query = "SELECT ID, DESCRIPTION, PLOTS, AMOUNT, CREATED_AT, APPROVED_AT FROM \"SIMULATION\" WHERE USER_ID = @UserId";
      return Query(query, new { UserId = userId });
    }

    public IEnumerable<SimulationModel> GetAll()
    {
      return Query("SELECT ID, DESCRIPTION, PLOTS, AMOUNT, CREATED_AT, APPROVED_AT FROM \"SIMULATION\"");
    }

    public void Approve(long id)
    {
      var query = "UPDATE \"SIMULATION\" SET  APPROVED_AT = @Date WHERE ID = @Id";
      Execute(query, new { Id = id, Date = DateTime.Now });
    }
  }
}