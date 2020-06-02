using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Npgsql;
using Site.Config;
using Site.Models;
using static System.Console;

namespace Site.Repository
{
  public abstract class BaseRepository<T> where T : BaseEntity
  {
    private readonly IDbConnection _conn;

    public IDbTransaction Transaction { get; private set; }

    protected BaseRepository(AppConfig config)
    {
      _conn = new NpgsqlConnection(config.ConnectionString);
    }

    protected void Execute(string query, object parameters = null)
    {
      try
      {
        Log(query);
        _conn.Execute(query, parameters);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }

    protected U ExecuteScalar<U>(string query, object parameters = null)
    {
      try
      {
        Log(query);
        return _conn.ExecuteScalar<U>(query, parameters);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }

    protected T FirstOrDefault(string query, object parameters = null)
    {
      try
      {
        Log(query);
        return _conn.QuerySingleOrDefault<T>(query, parameters);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }

    protected IEnumerable<T> Query(string query, object parameters = null)
    {
      try
      {
        Log(query);
        return _conn.Query<T>(query, parameters);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }

    public bool Exists(T entity)
    {
      try
      {
        var query = $"SELECT COUNT(1) FROM \"{entity.EntityName}\" WHERE \"ID\" = @Id";
        Log(query);
        return _conn.ExecuteScalar<long>(query, new { Id = entity.Id }) > 0;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }

    public long CurrentId(T entity)
    {
      try
      {
        var query = $"SELECT MAX(ID) FROM \"{entity.EntityName}\"";
        Log(query);
        return _conn.ExecuteScalar<long>(query);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
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