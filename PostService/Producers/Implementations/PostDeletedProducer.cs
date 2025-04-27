using PostService.Contracts;
using PostService.Producers.Abstractions;
using SubscriptionService.Data.RabbitMQ.Connection;

namespace PostService.Producers.Implementations
{
    public class PostDeletedProducer : Producer<PostDeletedEvent>, IPostDeletedProducer
    {
        public PostDeletedProducer(IRabbitMqConnection connection) : base(connection)
        {
        }
    }
}
