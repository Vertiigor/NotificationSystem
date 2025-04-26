using SubscriptionService.Models;

namespace SubscriptionService.Services.Abstractions
{
    public interface IUserService : IService<User>
    {
        public Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(string userId);
    }
}
