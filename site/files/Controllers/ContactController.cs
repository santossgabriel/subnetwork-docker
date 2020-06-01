using Microsoft.AspNetCore.Mvc;
using Site.Config;
using Site.Models;
using Site.Services;

namespace Site.Controllers
{
  public class ContactController : Controller
  {
    private readonly MailService _mailService;

    private readonly AppConfig _config;

    public ContactController(MailService mailService, AppConfig config)
    {
      _mailService = mailService;
      _config = config;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult SendMail(ContactModel model)
    {
      var email = new EmailModel();

      email.From = _config.Email.Sender;
      email.To = _config.Email.Contact;

      email.Subject = "Contato";
      email.Body = $"{model.Message}\n\nEmail para contato: {model.Email}";

      var success = _mailService.Send(email);
      if (success)
      {
        return View("Index");
      }
      else
      {
        return View("Index");
      }
    }
  }
}