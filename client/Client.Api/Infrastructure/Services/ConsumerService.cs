using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cliente.Api.Infrastructure.Interfaces;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Client.Api.Infrastructure.Services
{
    public class ConsumerService : BackgroundService, IConsumerService
    {
        private const string Exchange = "weather";
        private const string Queue = "weather";
        private const string RoutingKey = "";

        public ConsumerService()
        {
        }

        public string Consume()
        {
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
            string msg = null;
            consumer.Received += (ch, ea) =>
            {
                body = ea.Body.ToArray();
                channel.BasicAck(ea.DeliveryTag, false);
                msg = UTF8Encoding.UTF8.GetString(body);
                Console.WriteLine(msg);
            };

            var consumerTag = channel.BasicConsume(Queue, false, consumer);
            return msg;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var mensagem = Consume();
            await Task.FromResult(mensagem);
        }
    }
}