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

    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult SendMail(ContactModel model)
    {
      var email = new EmailModel();

      email.From = _config.Email.Sender;
      email.To = _config.Email.Contact;

      email.Subject = "Contato";
      email.Body = $"{model.Message}\n\n\nEmail para contato:\n {model.Email}";

      model.SendError = !_mailService.Send(email);
      return View("Index", model);
    }
  }
}