using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedKernel.CrossCutting;
using Labs.Api.Infraestructure.Events;
using Labs.Api.Domain.Repositories;

namespace labs.Controllers
{
    public class WeatherForecastController : GenericController
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherDomainService _weatherDomainService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         IWeatherDomainService weatherDomainService)
        {
            _logger = logger;
            this._weatherDomainService = weatherDomainService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(WeatherEvent), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var weatherList = await _weatherDomainService.ConsumeWeatherAPI();

            return Ok(weatherList);
        }
    }
}