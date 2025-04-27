using NotificationService.Data;
using NotificationService.Models;
using NotificationService.Repository.Abstractions;

namespace NotificationService.Repository.Implementations
{
    public class ChannelRepository : Repository<Channel>, IChannelRepository
    {
        public ChannelRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
