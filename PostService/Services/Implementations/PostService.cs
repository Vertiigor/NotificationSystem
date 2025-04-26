using SubscriptionService.Models;
using SubscriptionService.Producers.Abstractions;
using SubscriptionService.Repository.Abstractions;
using SubscriptionService.Services.Abstractions;

namespace SubscriptionService.Services.Implementations
{
    public class PostService : Service<Post>, IPostService
    {
        private readonly IPostRepository _userRepository;
        private readonly IMessageProducer _messageProducer;

        public PostService(IPostRepository userRepository, IMessageProducer messageProducer) : base(userRepository)
        {
            _userRepository = userRepository;
            _messageProducer = messageProducer;
        }

        public async Task Publish(Post post)
        {
            await _messageProducer.PublishMessageAsync(post, "posts");
        }
    }
}
