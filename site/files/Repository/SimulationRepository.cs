using System;
using System.Collections.Generic;
using Site.Config;
using Site.Models;

namespace Site.Repository
{
  public class SimulationRepository : BaseRepository<SimulationModel>
  {
    private const string SELECT_COLUMNS = "Id, Description, Plots, Amount, UserId, CreatedAt, ApprovedAt";

    public SimulationRepository(AppConfig config) : base(config) { }

    public long Add(SimulationModel simulation)
    {
      var query = "INSERT INTO \"Simulation\" (Description, Plots, Amount, UserId, CreatedAt) VALUES (@Description, @Plots, @Amount, @UserId, @CreatedAt)";
      simulation.CreatedAt = DateTime.Now;
      Execute(query, simulation);
      return CurrentId(simulation);
    }

    public SimulationModel GetById(long id)
    {
      var query = $"SELECT {SELECT_COLUMNS} FROM \"Simulation\" WHERE Id = @Id";
      return FirstOrDefault(query, new { Id = id });
    }

    public IEnumerable<SimulationModel> GetByUser(long userId)
    {
      var query = $"SELECT {SELECT_COLUMNS} FROM \"SIMULATION\" WHERE USER_ID = @UserId ORDER BY Id";
      return Query(query, new { UserId = userId });
    }

    public IEnumerable<SimulationModel> GetAll()
    {
      return Query($"SELECT {SELECT_COLUMNS} FROM \"Simulation\" ORDER BY Id");
    }

    public void Approve(long id)
    {
      var query = "UPDATE \"Simulation\" SET  ApprovedAt = @Date WHERE ID = @Id";
      Execute(query, new { Id = id, Date = DateTime.Now });
    }
  }
}