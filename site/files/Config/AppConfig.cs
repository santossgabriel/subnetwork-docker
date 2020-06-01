namespace Site.Config
{
  public class AppConfig
  {
    public EmailConfig Email { get; set; }

    public string ConnectionString { get; set; }
  }

  public class EmailConfig
  {
    public string Server { get; set; }

    public string User { get; set; }

    public string Password { get; set; }

    public bool UseDefaultCredentials { get; set; }

    public string Contact { get; set; }

    public string Sender { get; set; }
  }
}