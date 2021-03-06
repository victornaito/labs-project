using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedKernel.CrossCutting;

namespace SharedKernel.Infraestructure.RabbitMQ
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        private const string Exchange = "weather";
        private const string Queue = "weather";
        private const string RoutingKey = "";
        private const string RABBITMQ_PASSWORD = "bitnami";
        private const string RABBITMQ_USER = "user";
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
            using (IConnection connection = GetConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(Exchange, ExchangeType.Topic);
                    channel.QueueDeclare(Queue, true, false, false, null);
                    channel.QueueBind(Queue, Exchange, RoutingKey);

                    channel.BasicPublish(Exchange, RoutingKey, null, UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg)));
                }
            }
        }

        public void Subscribe<E, EH>()
            where E : Event
            where EH : IEventHandler<E>
        {
            StartBasicConsume(typeof(E), typeof(EH));
        }

        private string StartBasicConsume(Type eventType, Type typeEH)
        {
            IModel channel;
            EventingBasicConsumer consumer;
            GetEventConsumer(out channel, out consumer);

            try
            {
                string @event = null;
                var body = new byte[0];

                var _eventHandler = _provider.GetService(typeEH).GetType();
                var _eventHandlers = Activator.CreateInstance(_provider.GetService(typeEH).GetType(), null);

                consumer.Received += (ch, ea) =>
                {
                    body = ea.Body.ToArray();
                    @event = UTF8Encoding.UTF8.GetString(body);
                    _logger.LogTrace(@event);

                    var eventInstance = Activator.CreateInstance(eventType, @event);
                    var methods = _eventHandler.GetInterfaces()[0].GetMethod("Handle", new Type[] { eventType });
                    var task = (Task) methods.Invoke(_eventHandlers, new object[] { eventInstance });
                    task.GetAwaiter().GetResult();

                    channel.BasicAck(ea.DeliveryTag, true);
                };

                return channel.BasicConsume(Queue, false, consumer);
            }
            catch
            {
                channel.BasicNack(default, default,  true);
                throw;
            }
        }

        private static void GetEventConsumer(out IModel channel, out EventingBasicConsumer consumer)
        {
            var connection = GetConnectionFactory().CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(Exchange, ExchangeType.Topic);
            channel.QueueDeclare(Queue, true, false, false, null);
            channel.QueueBind(Queue, Exchange, RoutingKey);
            consumer = new EventingBasicConsumer(channel);
        }

        private static ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = VariableEnvironments.HOST_RABBITMQ,
                UserName = RABBITMQ_USER,
                Password = RABBITMQ_PASSWORD
            };
        }
    }
}