using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace labs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private const string Exchange = "weather";
        private const string Queue = "weather";
        private const string RoutingKey = "";

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly HttpClient _httpClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         HttpClient httpClient)
        {
            this._httpClient = httpClient;
            _logger = logger;
        }

        [HttpGet("producer")]
        public async Task<IActionResult> ObterClimasAsync()
        {
            var resultado = await _httpClient.GetFromJsonAsync<Weather>("https://api.hgbrasil.com/weather");
            
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.Password = "bitnami";
            connectionFactory.UserName = "user";
            IConnection connection = connectionFactory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.ExchangeDeclare(Exchange, ExchangeType.Topic);
            channel.QueueDeclare(Queue, true, false, false, null);
            channel.QueueBind(Queue, Exchange, RoutingKey);

            channel.BasicPublish(Exchange, RoutingKey, null, UTF8Encoding.UTF8.GetBytes(resultado.ToString()));

            connection.Close();

            return Ok(resultado);
        }

        public class Weather
        {
            public string By { get; set; }
            public bool Valid_key { get; set; }
            public Result Results { get; set; }

            public class Result
            {
                public float Temp { get; set; }
                public string Date { get; set; }
                public string Time { get; set; }
                public string city_name { get; set; }
                public List<ForeCast> Forecast { get; set; }

                public class ForeCast
                {
                    public string Date { get; set; }
                    public string Weekday { get; set; }
                    public float Max { get; set; }
                    public float Min { get; set; }
                }
            }
        }
    }
}
