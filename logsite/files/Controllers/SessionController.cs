using Microsoft.AspNetCore.Mvc;
using ProxyHttpsDotnet.Services;

namespace ProxyHttpsDotnet
{
  [ApiController]
  [Route("[controller]")]
  public class SessionController : ControllerBase
  {
    private LogService _service = new LogService();

    [HttpGet]
    public IActionResult Data([FromQuery] string data)
    {
      _service.Add(new LogModel(data));
      return Ok();
    }

    [HttpGet, Route("log")]
    public IActionResult Log([FromQuery] string data) => Ok(_service.All());
  }
}