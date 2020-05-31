using System.Net;
using System.Net.Mail;
using Site.Config;
using Site.Models;

namespace Site.Services
{
  public class MailService
  {
    private readonly EmailConfig _config;

    public MailService(AppConfig config) => _config = config.Email;

    public void Send(EmailModel model)
    {
      SmtpClient client = new SmtpClient();
      client.UseDefaultCredentials = _config.UseDefaultCredentials;
      client.Host = _config.Server;
      client.Credentials = new NetworkCredential(_config.User, _config.Password);

      MailMessage mailMessage = new MailMessage();
      mailMessage.From = new MailAddress(model.From);
      mailMessage.To.Add(model.To);
      mailMessage.Body = model.Body;
      mailMessage.Subject = model.Subject;
      client.Send(mailMessage);
    }
  }
}