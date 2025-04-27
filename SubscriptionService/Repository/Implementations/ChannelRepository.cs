using PostService.Data;
using PostService.Models;
using PostService.Repository.Abstractions;

namespace PostService.Repository.Implementations
{
    public class ChannelRepository : Repository<Channel>, IChannelRepository
    {
        public ChannelRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
