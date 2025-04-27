using NotificationSystem.Data;
using NotificationSystem.Models;
using NotificationSystem.Repository.Abstractions;

namespace NotificationSystem.Repository.Implementations
{
    public class ChannelRepository : Repository<Channel>, IChannelRepository
    {
        public ChannelRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
