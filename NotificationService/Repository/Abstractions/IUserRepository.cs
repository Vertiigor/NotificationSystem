using NotificationService.Models;

namespace NotificationService.Repository.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(string userId);
    }
}
