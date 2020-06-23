using System;
using Microsoft.AspNetCore.Mvc;
using Site.Config;
using Site.Extentions;
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
      if (!ModelState.IsValid)
        return BadRequestModel(ModelState);

      if (_userService.EmailAlreadyExists(model.Email))
        return BadRequest("Email já cadastrado.");

      var user = new UserModel();
      user.Email = model.Email;
      user.Name = model.Name.FirstLetterToUpper();
      user.Password = StringUtils.PasswordGenerate();
      user.Document = model.FilePath;
      _userService.Save(user);

      var email = new EmailModel();
      email.From = _config.Email.Contact;
      email.To = model.Email;
      email.Subject = "Senha de acesso";
      email.Body = $"Ola {user.Name}! \nRecebemos seu contato e ja preparamos um usuario pra voce. Basta acessar nosso site com o seu email utilizando a seguinte senha:\n{user.Password}\n\nO grupo Fake Bank agradece sua escolha!";

      model.SendError = !_mailService.Send(email);
      if (model.SendError)
        return BadRequest("Não foi possível solicitar cadastro.");

      return Ok("Dados de acesso foram enviados para o email informado.");
    }
  }
}