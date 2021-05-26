using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cliente.Cliente.Api.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cliente.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
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
        public IActionResult Post([FromBody] string name, [FromBody] short age)
        {
            _userRepository.SaveAsync(new cliente.Cliente.Api.Domain.User { Name = name, Age = age });
            return Ok();
        }
    }
}
