using SubscriptionService.Data;
using SubscriptionService.Models;
using SubscriptionService.Repository.Abstractions;

namespace SubscriptionService.Repository.Implementations
{
    public class ChannelRepository : Repository<Channel>, IChannelRepository
    {
        public ChannelRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
