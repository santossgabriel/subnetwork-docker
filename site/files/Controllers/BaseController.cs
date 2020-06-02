using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
  public class BaseController : Controller
  {
    protected int UserId
    {
      get
      {
        if (User.Identity.IsAuthenticated)
        {
          var claim = User.Claims.First(p => p.Type == ClaimTypes.Sid);
          return Convert.ToInt32(claim.Value);
        }
        return 0;
      }
    }
  }
}