using SubscriptionService.Models;

namespace SubscriptionService.Repository.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(string userId);
    }
}
