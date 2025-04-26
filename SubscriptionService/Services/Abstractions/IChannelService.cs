using SubscriptionService.Models;

namespace SubscriptionService.Services.Abstractions
{
    public interface IChannelService : IService<Channel>
    {
        public Task SubscribeToChannel(string userId, string channelId);
        public Task UnsubscribeFromChannel(string userId, string channelId);
        public Task<bool> IsUserSubscribedToChannel(string userId, string channelId);
        public Task<IEnumerable<User>> GetUsersSubscribedTo(string channelId);
    }
}
