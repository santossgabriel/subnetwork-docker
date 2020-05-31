using System.Net;
using System.Net.Mail;
using Site.Config;
using Site.Models;

namespace Site.Services
{
  public class MailService
  {
    private readonly EmailConfig _config;

    public MailService(EmailConfig config) => _config = config;

    public void Send(MailModel model)
    {
      SmtpClient client = new SmtpClient();
      client.UseDefaultCredentials = _config.UseDefaultCredentials;
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