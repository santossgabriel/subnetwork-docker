using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Site.Services;
using Site.Models;
using Microsoft.AspNetCore.Authorization;
using Cashflow.Api.Auth;
using Site.Config;
using Site.Utils;
using Site.Extentions;
using System.IO;
using System.Threading.Tasks;

namespace Site.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class AccountController : BaseController
  {
    private readonly UserService _userService;

    private readonly AppConfig _config;

    private readonly MailService _mailService;

    public AccountController(AppConfig config, UserService userService, MailService mailService)
    {
      _userService = userService;
      _config = config;
      _mailService = mailService;
    }

    [HttpPost, Route("login"), AllowAnonymous]
    public IActionResult Post([FromBody] UserModel model)
    {
      if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
        return Unauthorized("Credenciais inválidas");

      var login = _userService.Login(model.Email, model.Password);

      if (login is null)
        return Unauthorized("Credenciais inválidas");

      var claims = new List<Claim>()
      {
        new Claim(ClaimTypes.Role, ((int)login.Role).ToString()),
        new Claim(ClaimTypes.Name, login.Email),
        new Claim(ClaimTypes.Sid, login.Id.ToString())
      };

      var token = new JwtTokenBuilder(_config.JwtKey, claims).Build().Value;

      return Ok(new { token, email = login.Email, role = login.Role, name = login.Name });
    }

    [HttpPost, Route("password/reset"), AllowAnonymous]
    public IActionResult UpdatePassword([FromBody] UserModel model)
    {
      var password = StringUtils.PasswordGenerate();
      var user = _userService.UpdatePassword(model.Email, password);
      var email = new EmailModel();
      email.From = _config.Email.Contact;
      email.To = model.Email;
      email.Subject = "Senha redefinida";
      email.Body = $"Ola {user.Name.FirstLetterToUpper()}!\n\nSua senha foi redefinida para: \n\n{password}";
      if (!_mailService.Send(email))
        return BadRequest("Não foi possível redefinir a senha.");
      else
        return Ok("Um email foi enviado com a nova senha.");
    }

    [HttpPost, Route("upload/document"), AllowAnonymous]
    public async Task<IActionResult> Upload(UploadFileModel model)
    {
      var file = model.File;

      if (file.Length > 0)
      {
        const string uploadPath = "temp";
        if (!Directory.Exists(uploadPath))
          Directory.CreateDirectory(uploadPath);
        var fileName = StringUtils.HashGenerate() + file.FileName;
        using (var fs = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
        {
          await file.CopyToAsync(fs);
        }

        model.Source = $"{uploadPath}/{fileName}";
        model.Extension = Path.GetExtension(fileName).Substring(1);
      }
      return Ok(new { file = model.Source });
    }

    [HttpGet, Route("logout")]
    public IActionResult Logout()
    {
      HttpContext.SignOutAsync();
      return Ok();
    }
  }
}