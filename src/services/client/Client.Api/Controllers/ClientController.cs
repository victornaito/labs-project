using cliente.Cliente.Api.Domain.Abstractions;
using Microsoft.Extensions.Logging;

namespace Client.Api.Controllers
{
    public class ClientController : SharedKernel.CrossCutting.GenericController
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IUserRepository _userRepository;

        public ClientController(ILogger<ClientController> logger,
                                 IUserRepository userRepository)
        {
            _logger = logger;
            this._userRepository = userRepository;
        }
    }
}
