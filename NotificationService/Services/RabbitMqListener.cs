using NotificationSystem.Contracts;
using NotificationSystem.Data.RabbitMQ.Connection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace NotificationSystem.Services
{
    public class RabbitMqListener : BackgroundService
    {
        private readonly IRabbitMqConnection _rabbitMqConnection;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitMqListener(IRabbitMqConnection rabbitMqConnection, IServiceScopeFactory serviceScopeFactory)
        {
            _rabbitMqConnection = rabbitMqConnection;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var c = await _rabbitMqConnection.GetConnectionAsync();
                Console.WriteLine("✅ Connected to RabbitMQ successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to connect: {ex.Message}");
            }


            var connection = await _rabbitMqConnection.GetConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "posts",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            var eventRouter = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<EventRouter>();

            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                try
                {
                    var envelope = JsonSerializer.Deserialize<MessageEnvelope>(message, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (envelope != null)
                    {
                        await eventRouter.RouteAsync(envelope);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error processing message: {ex.Message}");
                }

                await channel.BasicAckAsync(ea.DeliveryTag, false);
            };

            await channel.BasicConsumeAsync(queue: "posts",
                autoAck: false,
                consumer: consumer);
        }
    }
}
