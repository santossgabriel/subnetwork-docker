using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services;

namespace Site.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class SimulationController : BaseController
  {
    private SimulationService _service;

    public SimulationController(SimulationService service) => _service = service;

    [HttpPost]
    public IActionResult Add([FromBody] SimulationModel simulation)
    {

      if (ModelState.IsValid)
      {
        simulation.UserId = UserId;
        simulation.Id = _service.Add(simulation);
        return Ok();
      }
      else
        return UnprocessableEntity();
    }

    [HttpPost, Route("approve")]
    public IActionResult Approve(long id)
    {
      _service.Approve(id);
      return Ok();
    }

    [HttpGet]
    public IActionResult Details(long id) => View(_service.Get(id, UserId));

    [HttpGet]
    public IActionResult List()
    {
      if (IsApprover)
        return Ok(_service.GetAll());

      return Ok(_service.GetByUser(UserId));
    }
  }
}