using RabbitMQ.Client;

namespace NotificationSystem.Data.RabbitMQ.Connection
{
    public interface IRabbitMqConnection
    {
        public Task<IConnection> GetConnectionAsync();
    }
}
