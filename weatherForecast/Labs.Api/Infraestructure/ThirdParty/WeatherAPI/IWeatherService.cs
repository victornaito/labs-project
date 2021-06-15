using System.Threading.Tasks;
using Labs.Api.Domain.AggregateWeather;

namespace Labs.Api.Infraestructure.ThirdParty.WeatherAPI
{
    public interface IWeatherService
    {
        Task<Weather> Consume();
    }
}