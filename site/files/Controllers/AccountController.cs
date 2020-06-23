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
using Microsoft.AspNetCore.StaticFiles;
using System.Linq;

namespace Site.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class AccountController : BaseController
  {
    private readonly string _uploadPath;

    private readonly UserService _userService;

    private readonly AppConfig _config;

    private readonly MailService _mailService;

    public AccountController(AppConfig config, UserService userService, MailService mailService)
    {
      _userService = userService;
      _config = config;
      _mailService = mailService;
      _uploadPath = $"{Directory.GetCurrentDirectory()}/upload";
    }

    [HttpPost, Route("login"), AllowAnonymous]
    public IActionResult Post([FromBody] UserModel model)
    {
      if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
        return Unauthorized("Credenciais inválidas.");

      var login = _userService.Login(model.Email, model.Password);

      if (login is null)
        return Unauthorized("Credenciais inválidas.");

      var claims = new List<Claim>()
      {
        new Claim(ClaimTypes.Role, ((int)login.Role).ToString()),
        new Claim(ClaimTypes.Name, login.Email),
        new Claim(ClaimTypes.Sid, login.Id.ToString())
      };

      var token = new JwtTokenBuilder(_config.JwtKey, claims).Build().Value;

      return Ok(new
      {
        token,
        email = login.Email,
        role = login.Role,
        name = login.Name,
        document = login.Document
      });
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

    [HttpPut]
    public IActionResult UpdateAccount([FromBody] UserModel model)
    {
      if (string.IsNullOrEmpty(model.Name))
        return BadRequest("Nome inválido.");

      if (string.IsNullOrEmpty(model.Document))
        return BadRequest("Documento inválido.");

      model.Id = UserId;

      var user = _userService.UpdateAccount(model);
      return Ok("Cadastro atualizado.");
    }

    [HttpPost, Route("document"), AllowAnonymous]
    public async Task<IActionResult> UploadDocument(UploadFileModel model)
    {
      var file = model.File;

      if (file.Length > 0)
      {
        if (!Directory.Exists(_uploadPath))
          Directory.CreateDirectory(_uploadPath);
        var fileName = StringUtils.HashGenerate() + file.FileName;
        using (var fs = new FileStream(Path.Combine(_uploadPath, fileName), FileMode.Create))
        {
          await file.CopyToAsync(fs);
        }

        model.Source = fileName;
        model.Extension = Path.GetExtension(fileName).Substring(1);
      }
      return Ok(new { file = model.Source });
    }

    [HttpGet, Route("document/{name}")]
    public IActionResult DownloadDocument(string name)
    {
      var file = $"{_uploadPath}/{name}";
      if (System.IO.File.Exists(file))
      {
        var provider = new FileExtensionContentTypeProvider();
        string contentType;
        if (!provider.TryGetContentType(file, out contentType))
          contentType = "application/octet-stream";
        var bytes = System.IO.File.ReadAllBytes(file);
        return Ok(new { bytes = bytes.ToList(), contentType });
      }
      return NotFound();
    }

    [HttpGet, Route("logout")]
    public IActionResult Logout()
    {
      HttpContext.SignOutAsync();
      return Ok();
    }
  }
}