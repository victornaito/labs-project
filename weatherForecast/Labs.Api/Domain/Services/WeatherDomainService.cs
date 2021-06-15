using System.Threading.Tasks;
using Labs.Api.Application.Queries.Dtos;
using Labs.Api.Domain.Repositories;
using Labs.Api.Infraestructure.ThirdParty.WeatherAPI;
using SharedKernel.Domain;

namespace Labs.Api.Domain.Services
{
    public class WeatherDomainService : DomainService, IWeatherDomainService
    {
        private readonly IWeatherService _weatherService;

        public WeatherDomainService(IWeatherService weatherService)
        {
            this._weatherService = weatherService;
        }

        public async Task<WeatherDTO> ConsumeWeatherAPI()
        {
            var weather = await _weatherService.ConsumeAsync();
            return weather.ConvertToDTO();
        }
    }
}