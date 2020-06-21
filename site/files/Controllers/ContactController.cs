using System;
using Microsoft.AspNetCore.Mvc;
using Site.Config;
using Site.Models;
using Site.Services;
using Site.Utils;

namespace Site.Controllers
{
  [Route("api/[controller]")]
  public class ContactController : BaseController
  {
    private readonly MailService _mailService;

    private readonly UserService _userService;

    private readonly AppConfig _config;

    public ContactController(MailService mailService,
      AppConfig config,
      UserService userService
    )
    {
      _mailService = mailService;
      _userService = userService;
      _config = config;
    }

    [HttpPost]
    public IActionResult Contact([FromBody] ContactModel model)
    {
      var user = new UserModel();
      user.Email = model.Email;
      user.Name = model.Name;
      user.Password = StringUtils.PasswordGenerate();
      _userService.Save(user);

      var email = new EmailModel();
      email.From = _config.Email.Contact;
      email.To = model.Email;
      email.Subject = "Senha de acesso";
      email.Body = $"Olá {model.Name}, recebemos seu contato e já preparamos um usuário pra você. Basta acessar nosso site com o seu email utilizando a seguinte senha:\n{user.Password}\n\nO grupo Fake Bank agradece sua escolha!";

      model.SendError = !_mailService.Send(email);
      if (model.SendError)
        return UnprocessableEntity("Não foi possível solicitar cadastro.");

      return Ok("Dados de acesso foram enviados para o email informado.");
    }
  }
}