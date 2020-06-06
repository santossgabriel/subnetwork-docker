using Microsoft.AspNetCore.Mvc;
using Site.Enums;
using Site.Models;
using Site.Services;

namespace Site.Controllers
{
  public class SimulationController : BaseController
  {
    private SimulationService _service;

    public SimulationController(SimulationService service) => _service = service;

    [HttpGet]
    public IActionResult Index() => View(new SimulationModel());

    [HttpPost]
    public IActionResult Add(SimulationModel simulation)
    {

      if (ModelState.IsValid)
      {
        simulation.UserId = LoggedUser.Id;
        simulation.Id = _service.Add(simulation);
        return RedirectToAction("Details", new { id = simulation.Id });
      }
      else
        return View("Index", simulation);
    }

    [HttpGet]
    public IActionResult Details(long id) => View(_service.Get(id, LoggedUser.Id));

    [HttpGet]
    public IActionResult List()
    {
      if (LoggedUser.Role == UserRole.Approver)
        return View(_service.GetAll());

      return View(_service.GetByUser(LoggedUser.Id));
    }
  }
}