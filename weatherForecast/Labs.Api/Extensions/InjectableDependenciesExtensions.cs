using System.Net.Http;
using Labs.Api.Domain.Repositories;
using Labs.Api.Domain.Services;
using Labs.Api.Infraestructure.ThirdParty;
using Labs.Api.Infraestructure.ThirdParty.WeatherAPI;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infraestructure.RabbitMQ;

namespace Labs.Api.Extensions
{
    public static class InjectableDependenciesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IWeatherDomainService, WeatherDomainService>();
            services.AddScoped<IRabbitMQConnection, RabbitMQConnection>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}