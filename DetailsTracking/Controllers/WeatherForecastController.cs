using DetailsTracking.Model;
using Microsoft.AspNetCore.Mvc;

namespace DetailsTracking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IPersonalDetailsService _IpersonalDetailsService;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPersonalDetailsService ipersonalDetailsService)
        {
            _IpersonalDetailsService= ipersonalDetailsService;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            [HttpGet]
            IActionResult GetAll()
            {
                List<PersonalDetail> lResult = _IpersonalDetailsService.GetAll();
                return Ok(lResult);
            }

            [HttpGet]
            IActionResult search(string PName)
            {
                List<PersonalDetail> lResult = _IpersonalDetailsService.GetByName(PName);
                return Ok(lResult);
            }

            [HttpPut]
            IActionResult Update(PersonalDetail personalDetail)
            {
                return Ok(_IpersonalDetailsService.Update(personalDetail));
            }
            [HttpPost]
            IActionResult Save(PersonalDetail personalDetail)
            {
                return Ok(_IpersonalDetailsService.Save(personalDetail));
            }

            IActionResult Delete(PersonalDetail personalDetail)
            {
                _IpersonalDetailsService.Delete(personalDetail);
                return Ok();
            }











            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}