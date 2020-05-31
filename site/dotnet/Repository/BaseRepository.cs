using System.Collections.Generic;
using System.Data;
using Dapper;
using Npgsql;
using Site.Config;
using static System.Console;

namespace Site.Repository
{
  public abstract class BaseRepository<T> where T : class
  {
    private readonly IDbConnection _conn;

    public IDbTransaction Transaction { get; private set; }

    protected BaseRepository(AppConfig config)
    {
      _conn = new NpgsqlConnection(config.ConnectionString);
    }

    protected void Execute(string query, object parameters = null)
    {
      Log(query);
      _conn.Execute(query, parameters);
    }

    protected U ExecuteScalar<U>(string query, object parameters = null)
    {
      Log(query);
      return _conn.ExecuteScalar<U>(query, parameters);
    }

    protected T FirstOrDefault(string query, object parameters = null)
    {
      Log(query);
      return _conn.QuerySingleOrDefault<T>(query, parameters);
    }

    protected IEnumerable<T> Query(string query, object parameters = null)
    {
      Log(query);
      return _conn.Query<T>(query, parameters);
    }

    public bool Exists(long id)
    {
      var query = $"SELECT COUNT(1) FROM \"{typeof(T).Name}\" WHERE \"Id\" = @Id";
      Log(query);
      return _conn.ExecuteScalar<long>(query, new { Id = id }) > 0;
    }

    public long NextId()
    {
      var query = $"SELECT MAX(\"Id\") FROM \"{typeof(T).Name}\"";
      Log(query);
      return _conn.ExecuteScalar<long>(query);
    }

    private void Log(string query)
    {
      WriteLine("");
      WriteLine("");
      WriteLine($"Query:{query}");
      WriteLine("");
      WriteLine("");
    }
  }
}