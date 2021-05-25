using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cliente.Cliente.Api.Domain;
using cliente.Cliente.Api.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

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
        public async Task<IActionResult> Post([FromBody] int age, [FromBody] string name)
        {
            await _userRepository.SaveAsync(new User { Age = age, Name = name});
            return Ok();
        }
    }
}
