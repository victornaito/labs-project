using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Labs.Api.Domain.AggregateWeather;
using Labs.Api.Infraestructure.ThirdParty.WeatherAPI;
using Microsoft.Extensions.Logging;
using SharedKernel.CrossCutting;

namespace Labs.Api.Infraestructure.ThirdParty
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public WeatherService(HttpClient httpClient,
                             ILogger<WeatherService> logger)
        {
            this._httpClient = httpClient;
            this._logger = logger;
        }

        public async Task<Weather> Consume()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Weather>(VariableEnvironments.WEATHER_API);
            }
            catch (System.Exception e)
            {
                _logger.LogTrace(new EventId(), e, "It was not possible getting weatherAPI response");
                throw;
            }
        }
    }
}