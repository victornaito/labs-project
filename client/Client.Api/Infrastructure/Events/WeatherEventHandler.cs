using System.Threading.Tasks;
using SharedKernel.Infraestructure.RabbitMQ;

namespace Cliente.Api.Infrastructure.Events
{
    public class WeatherEventHandler : IEventHandler<WeatherEvent>
    {
        public WeatherEventHandler()
        {
        }

        public static async Task Handle(WeatherEvent @event)
        {
            await Task.FromResult(@event);
        }
    }
}