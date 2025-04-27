using PostService.Models;

namespace PostService.Repository.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(string userId);
    }
}
