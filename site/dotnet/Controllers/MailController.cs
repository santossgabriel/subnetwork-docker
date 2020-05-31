using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services;

namespace Site.Controllers
{
  public class MailController : Controller
  {
    private readonly MailService _mailService;
    public MailController(MailService mailService)
    {
      _mailService = mailService;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult SendMail(MailModel model)
    {
      _mailService.Send(model);
      return View("Index");
    }
  }
}