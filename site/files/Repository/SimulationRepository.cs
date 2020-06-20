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
      var query = $"INSERT INTO \"{TableName}\" (Description, Plots, Amount, UserId, CreatedAt) VALUES (@Description, @Plots, @Amount, @UserId, @CreatedAt)";
      simulation.CreatedAt = DateTime.Now;
      Execute(query, simulation);
      return CurrentId(simulation);
    }

    public SimulationModel GetById(long id)
    {
      var query = $"SELECT {SELECT_COLUMNS} FROM \"{TableName}\" WHERE Id = @Id";
      return FirstOrDefault(query, new { Id = id });
    }

    public IEnumerable<SimulationModel> GetByUser(long userId)
    {
      var query = $"SELECT {SELECT_COLUMNS} FROM \"{TableName}\" WHERE UserId = @UserId ORDER BY Id";
      return Query(query, new { UserId = userId });
    }

    public IEnumerable<SimulationModel> GetAll()
    {
      return Query($"SELECT {SELECT_COLUMNS} FROM \"{TableName}\" ORDER BY Id");
    }

    public void Approve(long id)
    {
      var query = $"UPDATE \"{TableName}\" SET  ApprovedAt = @Date WHERE ID = @Id";
      Execute(query, new { Id = id, Date = DateTime.Now });
    }
  }
}