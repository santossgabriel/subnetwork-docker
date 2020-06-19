using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Site.Services;
using Site.Models;
using Microsoft.AspNetCore.Authorization;

namespace Site.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class AccountController : Controller
  {
    private readonly UserService _userService;

    public AccountController(UserService userService) => _userService = userService;

    [HttpPost, Route("login"), AllowAnonymous]
    public IActionResult Post([FromBody] UserModel model)
    {
      if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
        return Unauthorized();

      var login = _userService.Login(model.Email, model.Password);

      if (login is null)
        return Unauthorized();

      var claims = new List<Claim>()
      {
        new Claim(ClaimTypes.Role, ((int)login.Role).ToString()),
        new Claim(ClaimTypes.Name, login.Email),
        new Claim(ClaimTypes.Sid, login.Id.ToString())
      };

      var identity = new ClaimsIdentity(claims, "User Identity");
      var userPrincipal = new ClaimsPrincipal(new[] { identity });

      HttpContext.SignInAsync(userPrincipal);
      return Ok(login);
    }

    [HttpGet, Route("logout")]
    public IActionResult Logout()
    {
      HttpContext.SignOutAsync();
      return Ok();
    }
  }
}