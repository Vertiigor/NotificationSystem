using SubscriptionService.Models;

namespace SubscriptionService.Services.Abstractions
{
    public interface IPostService : IService<Post>
    {
        public Task Publish(Post post);
    }
}
