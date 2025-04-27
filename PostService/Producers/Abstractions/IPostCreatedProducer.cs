using SubscriptionService.Contracts;
using SubscriptionService.Producers.Abstractions;

namespace PostService.Producers.Abstractions
{
    public interface IPostCreatedProducer : IMessageProducer<PostCreatedEvent>
    {
    }
}
