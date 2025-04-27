using RabbitMQ.Client;

namespace PostService.Data.RabbitMQ.Connection
{
    public interface IRabbitMqConnection
    {
        public Task<IConnection> GetConnectionAsync();
    }
}
