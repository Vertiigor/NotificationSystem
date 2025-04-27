using NotificationSystem.Models;

namespace NotificationSystem.Services.Abstractions
{
    public interface IUserService : IService<User>
    {
        public Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(string userId);
    }
}
