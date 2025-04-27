using RabbitMQ.Client;

namespace NotificationService.Data.RabbitMQ.Connection
{
    public interface IRabbitMqConnection
    {
        public Task<IConnection> GetConnectionAsync();
    }
}
