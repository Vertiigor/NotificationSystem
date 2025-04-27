namespace SubscriptionService.Producers.Abstractions
{
    public interface IMessageProducer<T> where T : class
    {
        public Task PublishMessageAsync(T message,
            string queue,
            bool durable = false,
            bool exlusive = false,
            bool autoDelete = false,
            Dictionary<string, object?> arguments = null,
            string exchange = "");
    }
}
