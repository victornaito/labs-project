using System.Threading.Tasks;
using Labs.Api.Infraestructure.Events;

namespace Labs.Api.Infraestructure.ThirdParty.WeatherAPI
{
    public interface IWeatherService
    {
        Task<WeatherEvent> ConsumeAsync();
    }
}