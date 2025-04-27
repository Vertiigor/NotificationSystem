using Microsoft.EntityFrameworkCore;
using PostService.Data;
using PostService.Models;
using PostService.Repository.Abstractions;

namespace PostService.Repository.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(string userId)
        {
            var userWithSubscriptions = await _context.Users
                .Include(u => u.Subscriptions)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (userWithSubscriptions == null)
            {
                return Enumerable.Empty<Channel>();
            }

            return userWithSubscriptions.Subscriptions;
        }
    }
}
