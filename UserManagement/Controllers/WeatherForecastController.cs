using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.DataAccess.Common;

namespace UserManagement.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
          "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
      };

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
      return Ok(Summaries);
    }

    [HttpGet]
    [Authorize(Roles = StaticUserRolesString.Admin)]
    [Route("GetWeatherForecastAdmin")]
    public IActionResult GetAdminAuth()
    {
      return Ok(Summaries);
    }

    [HttpGet]
    [Authorize(Roles = StaticUserRolesString.User)]
    [Route("GetWeatherForecastUser")]
    public IActionResult GetUserAuth()
    {
      return Ok(Summaries);
    }
  }
}
