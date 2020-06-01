using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services;

namespace Site.Controllers
{
  public class SimulationController : Controller
  {
    private SimulationService _service;

    public SimulationController(SimulationService service) => _service = service;

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Post([FromBody] Simulation simulation)
    {
      if (!string.IsNullOrEmpty(simulation?.Description))
      {
        _service.Add(simulation);
        return Ok();
      }
      else
        return UnprocessableEntity("Invalid request");
    }

  }
}