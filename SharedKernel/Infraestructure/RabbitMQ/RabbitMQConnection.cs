using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SharedKernel.Infraestructure.RabbitMQ
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        private const string Exchange = "weather";
        private const string Queue = "weather";
        private const string RoutingKey = "";
        private readonly IServiceProvider _provider;
        private readonly ILogger<RabbitMQConnection> _logger;

        public RabbitMQConnection(IServiceProvider provider,
                                  ILogger<RabbitMQConnection> _logger)
        {
            this._provider = provider;
            this._logger = _logger;
        }

        public void Publish(Event msg)
        {
            throw new System.NotImplementedException();
        }

        public void Subscribe<E, EH>()
            where E : Event
            where EH : IEventHandler<E>
        {
            StartBasicConsume(typeof(E), typeof(EH));
        }

        private string StartBasicConsume(Type eventType, Type typeEH)
        {
            var _eventHandler  = _provider.GetService(typeEH).GetType();
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.UserName = "user";
            connectionFactory.Password = "bitnami";
            IConnection connection = connectionFactory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.ExchangeDeclare(Exchange, ExchangeType.Topic);
            channel.QueueDeclare(Queue, true, false, false, null);
            channel.QueueBind(Queue, Exchange, RoutingKey);
            var body = new byte[0];
            var consumer = new EventingBasicConsumer(channel);
            string @event = null;
            consumer.Received += (ch, ea) =>
            {

                body = ea.Body.ToArray();
                channel.BasicAck(ea.DeliveryTag, false);
                @event = UTF8Encoding.UTF8.GetString(body);
                _logger.LogTrace(@event);

                var eventInstance = Activator.CreateInstance(eventType, @event);
                
                var method = _eventHandler.GetMethod("Handle", new Type[] { eventType });
                var task = (Task) method.Invoke(eventInstance, new Object[] { eventInstance });
                task.GetAwaiter().GetResult();
            };

            var consumerTag = channel.BasicConsume(Queue, false, consumer);
            return @event;
        }
    }
}