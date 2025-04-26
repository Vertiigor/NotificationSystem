namespace SubscriptionService.Producers.Abstractions
{
    public interface IMessageProducer
    {
        public Task PublishMessageAsync<T>(T message,
            string queue,
            bool durable = false,
            bool exlusive = false,
            bool autoDelete = false,
            Dictionary<string, object?> arguments = null,
            string exchange = "");
    }
}
