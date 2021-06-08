using System.Text;
using System;
using cliente.Cliente.Api.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Cliente.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private const string Exchange = "weather";
        private const string Queue = "weather";
        private const string RoutingKey = "";
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ClienteController> _logger;
        private readonly IUserRepository _userRepository;

        public ClienteController(ILogger<ClienteController> logger,
                                 IUserRepository userRepository)
        {
            _logger = logger;
            this._userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            _userRepository.SaveAsync(new cliente.Cliente.Api.Domain.User { Name = name, Age = 34 });
            return Ok();
        }

        [HttpPost("consumer")]
        public IActionResult Consumer()
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
            consumer.Received += (ch, ea) =>
                            {
                                body = ea.Body.ToArray();
                                // copy or deserialise the payload
                                // and process the message
                                // ...
                                channel.BasicAck(ea.DeliveryTag, false);
                            };
            // this consumer tag identifies the subscription
            // when it has to be cancelled
            String consumerTag = channel.BasicConsume(Queue, false, consumer);

            connection.Close();
            return Ok(UTF8Encoding.UTF8.GetString(body));
        }
    }
}
