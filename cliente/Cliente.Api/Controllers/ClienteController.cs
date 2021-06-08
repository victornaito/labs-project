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
    }
}
