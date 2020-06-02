using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Site.Models;
using Site.Services;

namespace Site.Controllers
{
  public class HomeController : Controller
  {
    private readonly UserService _userService;

    public HomeController(ILogger<HomeController> logger, UserService userService) => _userService = userService;

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy() => View();

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
      if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        return View("Index");

      var login = _userService.Login(email, password);

      if (login is null)
        return View("Index");

      var claims = new List<Claim>()
      {
        new Claim(ClaimTypes.Role, "Administrator"),
        new Claim(ClaimTypes.Name, login.Email),
        new Claim(ClaimTypes.Sid, login.Id.ToString())
      };

      var identity = new ClaimsIdentity(claims, "User Identity");
      var userPrincipal = new ClaimsPrincipal(new[] { identity });

      HttpContext.SignInAsync(userPrincipal);
      return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
      var name = User.Identity.Name;
      HttpContext.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}