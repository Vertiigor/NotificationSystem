using SubscriptionService.Data;
using SubscriptionService.Models;
using SubscriptionService.Repository.Abstractions;

namespace SubscriptionService.Repository.Implementations
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
