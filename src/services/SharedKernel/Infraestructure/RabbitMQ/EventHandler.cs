using System.Threading.Tasks;

namespace SharedKernel.Infraestructure.RabbitMQ
{
    public interface IEventHandler<T> : IEventHandler where T : Event
    {
        public static async Task Handle(T msg)
        {
            await Task.CompletedTask;
        }
    }
}