using System.Threading.Tasks;

namespace SharedKernel.Infraestructure.RabbitMQ
{
    public interface IEventHandler<T> : IEventHandler where T : Event
    {
        Task Handle(T msg);
    }
}