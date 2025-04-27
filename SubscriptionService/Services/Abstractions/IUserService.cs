using NotificationService.Models;

namespace NotificationService.Services.Abstractions
{
    public interface IUserService : IService<User>
    {
        public Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(string userId);
    }
}
