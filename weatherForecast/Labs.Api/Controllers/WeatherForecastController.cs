using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Newtonsoft.Json;
using SharedKernel.CrossCutting;
using Labs.Api.Domain.AggregateWeather;
using Labs.Api.Infraestructure.ThirdParty.WeatherAPI;

namespace labs.Controllers
{
    public class WeatherForecastController : GenericController
    {
        
        private const string Exchange = "weather";
        private const string Queue = "weather";
        private const string RoutingKey = "";

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         IWeatherService weatherService)
        {
            _logger = logger;
            this._weatherService = weatherService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Weather), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var weatherList = await _weatherService.Consume();
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.Password = "bitnami";
            connectionFactory.UserName = "user";
            IConnection connection = connectionFactory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.ExchangeDeclare(Exchange, ExchangeType.Topic);
            channel.QueueDeclare(Queue, true, false, false, null);
            channel.QueueBind(Queue, Exchange, RoutingKey);

            channel.BasicPublish(Exchange, RoutingKey, null, UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(weatherList)));

            connection.Close();

            return Ok(weatherList);
        }
    }
}
