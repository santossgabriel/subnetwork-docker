using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Site.Enums;
using Site.Models;

namespace Site.Controllers
{
  public class BaseController : Controller
  {
    private UserModel _user;

    protected UserModel LoggedUser
    {
      get
      {
        if (_user is null && User.Identity.IsAuthenticated)
        {
          _user = new UserModel();
          _user.Id = Convert.ToInt32(User.Claims.First(p => p.Type == ClaimTypes.Sid).Value);
          _user.Role = (UserRole)Convert.ToInt32(User.Claims.First(p => p.Type == ClaimTypes.Role).Value);
          return _user;
        }
        return new UserModel();
      }
    }
  }
}