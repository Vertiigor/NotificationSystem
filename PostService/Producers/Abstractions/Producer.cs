﻿using RabbitMQ.Client;
using SubscriptionService.Data.RabbitMQ.Connection;
using SubscriptionService.Producers.Abstractions;
using System.Text;
using System.Text.Json;

namespace PostService.Producers.Abstractions
{
    public class Producer<T> : IMessageProducer<T> where T : class
    {
        private readonly IRabbitMqConnection _connection;

        public Producer(IRabbitMqConnection connection)
        {
            _connection = connection;
        }

        public async Task PublishMessageAsync(
            T message,
            string queue,
            bool durable = false,
            bool exlusive = false,
            bool autoDelete = false,
            Dictionary<string, object?> arguments = null,
            string exchange = "")
        {
            var connection = await _connection.GetConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: queue,
                                     durable: durable,
                                     exclusive: exlusive,
                                     autoDelete: autoDelete,
                                     arguments: arguments);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(exchange: exchange,
                routingKey: queue,
                body: body);
        }
    }
}
