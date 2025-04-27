using PostService.Models;

namespace PostService.Services.Abstractions
{
    public interface IUserService : IService<User>
    {
        public Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(string userId);
    }
}
