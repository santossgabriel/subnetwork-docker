namespace ProxyHttpsDotnet
{
  public class LogModel
  {
    public string Data { get; set; }

    public string Date { get; set; }

    public LogModel() { }

    public LogModel(string data)
    {
      Data = data;
      Date = System.DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
    }
  }
}