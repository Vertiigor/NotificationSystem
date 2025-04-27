using NotificationSystem.Data;
using NotificationSystem.Models;
using NotificationSystem.Repository.Abstractions;

namespace NotificationSystem.Repository.Implementations
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
