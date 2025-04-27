using PostService.Data;
using PostService.Models;
using PostService.Repository.Abstractions;

namespace PostService.Repository.Implementations
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
