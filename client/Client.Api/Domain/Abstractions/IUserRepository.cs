using System.Threading.Tasks;

namespace cliente.Cliente.Api.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task SaveAsync(User user);
    }
}