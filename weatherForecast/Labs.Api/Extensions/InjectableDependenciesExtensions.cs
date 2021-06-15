using System.Net.Http;
using Labs.Api.Infraestructure.ThirdParty;
using Labs.Api.Infraestructure.ThirdParty.WeatherAPI;
using Microsoft.Extensions.DependencyInjection;

namespace Labs.Api.Extensions
{
    public static class InjectableDependenciesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddScoped<IWeatherService, WeatherService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}