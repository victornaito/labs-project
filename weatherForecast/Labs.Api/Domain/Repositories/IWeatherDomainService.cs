using System.Threading.Tasks;
using Labs.Api.Application.Queries.Dtos;

namespace Labs.Api.Domain.Repositories
{
    public interface IWeatherDomainService
    {
        Task<WeatherDTO> ConsumeWeatherAPI();
    }
}