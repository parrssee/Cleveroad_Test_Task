using Cleveroad_Test_Task.Domains;
using Cleveroad_Test_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Cleveroad_Test_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherDomain Domain;

        public HomeController(IOptions<ApiConfig> config)
        {
            Domain = new WeatherDomain(config.Value);
        }

        [HttpGet("api/current")]
        public IActionResult GetCurrent([Required] string city)
        {
            return Ok(Domain.GetCurrent(city));
        }

        [HttpGet("api/forecast")]
        public IActionResult GetForecast([Required] string city)
        {
            return Ok(Domain.GetForecast(city));
        }
    }
}
