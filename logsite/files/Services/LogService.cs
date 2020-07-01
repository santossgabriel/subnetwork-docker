using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProxyHttpsDotnet.Services
{
  public class LogService
  {
    private string _logPath = "./log.json";

    public LogService()
    {
      if (!File.Exists(_logPath))
        File.WriteAllText(_logPath, "[]");
    }

    public void Add(LogModel log)
    {
      var list = JsonSerializer.Deserialize<List<LogModel>>(File.ReadAllText(_logPath));
      list.Add(log);
      File.WriteAllText(_logPath, JsonSerializer.Serialize(list));
    }

    public List<LogModel> All() => JsonSerializer.Deserialize<List<LogModel>>(File.ReadAllText(_logPath));
  }
}