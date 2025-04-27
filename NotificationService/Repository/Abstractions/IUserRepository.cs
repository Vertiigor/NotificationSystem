using NotificationSystem.Models;

namespace NotificationSystem.Repository.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(string userId);
    }
}
