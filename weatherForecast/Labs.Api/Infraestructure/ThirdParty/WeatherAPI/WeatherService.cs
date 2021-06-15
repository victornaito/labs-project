using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Labs.Api.Infraestructure.Events;
using Labs.Api.Infraestructure.ThirdParty.WeatherAPI;
using Microsoft.Extensions.Logging;
using SharedKernel.CrossCutting;
using SharedKernel.Infraestructure.RabbitMQ;

namespace Labs.Api.Infraestructure.ThirdParty
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private readonly IRabbitMQConnection _rabbitMQConnection;

        public WeatherService(HttpClient httpClient,
                             ILogger<WeatherService> logger,
                             IRabbitMQConnection rabbitMQConnection)
        {
            this._httpClient = httpClient;
            this._logger = logger;
            this._rabbitMQConnection = rabbitMQConnection;
        }

        public async Task<WeatherEvent> ConsumeAsync()
        {
            try
            {
                var weatherResponse = await _httpClient.GetFromJsonAsync<WeatherEvent>(VariableEnvironments.WEATHER_API);
                _rabbitMQConnection.Publish(weatherResponse);
                return weatherResponse;
            }
            catch (System.Exception e)
            {
                _logger.LogTrace(new EventId(), e, "It was not possible getting weatherAPI response");
                throw;
            }
        }
    }
}