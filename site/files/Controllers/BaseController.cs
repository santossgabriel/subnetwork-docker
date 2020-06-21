using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Site.Enums;

namespace Site.Controllers
{
  public class BaseController : Controller
  {
    protected bool IsApprover => User.Identity.IsAuthenticated && User.IsInRole(((int)UserRole.Approver).ToString());

    protected long UserId
    {
      get
      {
        if (User.Identity.IsAuthenticated)
          return Convert.ToInt64(User.Claims.First(p => p.Type == ClaimTypes.Sid).Value);

        return 0;
      }
    }

    protected BadRequestObjectResult BadRequest(string error) => BadRequest(new { error });

    protected OkObjectResult Ok(string message) => Ok(new { message });
  }
}