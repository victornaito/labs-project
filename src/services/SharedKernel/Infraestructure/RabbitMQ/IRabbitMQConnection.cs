namespace SharedKernel.Infraestructure.RabbitMQ
{
    public interface IRabbitMQConnection
    {
        void Publish(Event msg);
        void Subscribe<E, EH>()
        where E : Event
        where EH : IEventHandler<E>;
    }
}