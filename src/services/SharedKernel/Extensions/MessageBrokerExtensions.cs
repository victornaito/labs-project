using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infraestructure.RabbitMQ;

namespace SharedKernel.Extensions
{
    public static class MessageBrokerExtensions
    {

        public static void Subscribe<EH, T>(this IServiceCollection services)
                                                    where EH : IEventHandler<T>
                                                    where T : Event
        {
            var defaultServiceProviderFactory = new DefaultServiceProviderFactory();
            var _rabbitMQConnection  = defaultServiceProviderFactory.CreateServiceProvider(services).GetRequiredService(typeof(IRabbitMQConnection)) as IRabbitMQConnection;
            _rabbitMQConnection.Subscribe<T, EH>();
        }
    }
}