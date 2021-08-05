using System.Threading.Tasks;
using Cliente.Api.Infrastructure.Interfaces;
using SharedKernel.Infraestructure.RabbitMQ;

namespace Cliente.Api.Infrastructure.Events
{
    public class WeatherEventHandler : IEventHandler<WeatherEvent>
    {
        public WeatherEventHandler()
        {
        }

        public async Task Handle(WeatherEvent @event)
        {
            await Task.FromResult(@event);
        }
    }
}