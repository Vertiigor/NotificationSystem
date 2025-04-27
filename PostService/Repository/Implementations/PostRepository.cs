using NotificationService.Data;
using NotificationService.Models;
using NotificationService.Repository.Abstractions;

namespace NotificationService.Repository.Implementations
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
