using PostService.Producers.Abstractions;
using SubscriptionService.Contracts;
using SubscriptionService.Data.RabbitMQ.Connection;

namespace PostService.Producers.Implementations
{
    public class PostCreatedProducer : Producer<PostCreatedEvent>, IPostCreatedProducer
    {
        public PostCreatedProducer(IRabbitMqConnection connection) : base(connection)
        {
        }
    }
}
