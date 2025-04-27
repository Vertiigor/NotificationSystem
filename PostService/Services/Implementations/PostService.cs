using PostService.Contracts;
using PostService.Models;
using PostService.Producers.Abstractions;
using PostService.Repository.Abstractions;
using PostService.Services.Abstractions;

namespace PostService.Services.Implementations
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
