using System;

namespace Site.Config
{
  public class AppConfig
  {
    public AppConfig()
    {
      ConnectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
      Email = new EmailConfig();
      Email.Server = Environment.GetEnvironmentVariable("EMAIL_SERVER");
      Email.User = Environment.GetEnvironmentVariable("EMAIL_USER");
      Email.Password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
      Email.UseDefaultCredentials = Environment.GetEnvironmentVariable("EMAIL_USE_DEFAULT_CREDENTIALS") == "true";
      Email.Contact = Environment.GetEnvironmentVariable("EMAIL_CONTACT");
      Email.Sender = Environment.GetEnvironmentVariable("EMAIL_SENDER");
    }

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