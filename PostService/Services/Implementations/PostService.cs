using NotificationSystem.Models;
using NotificationSystem.Producers.Abstractions;
using NotificationSystem.Repository.Abstractions;
using NotificationSystem.Services.Abstractions;

namespace NotificationSystem.Services.Implementations
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

        public Task Publish<T>(string eventType, T payload)
        {
            return _messageProducer.PublishMessageAsync(eventType, payload, "posts");
        }
    }
}
