using PostService.Contracts;
using SubscriptionService.Producers.Abstractions;

namespace PostService.Producers.Abstractions
{
    public interface IPostDeletedProducer : IMessageProducer<PostDeletedEvent>
    {
    }
}
