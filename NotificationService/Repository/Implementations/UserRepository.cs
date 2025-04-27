using Microsoft.EntityFrameworkCore;
using NotificationSystem.Data;
using NotificationSystem.Models;
using NotificationSystem.Repository.Abstractions;

namespace NotificationSystem.Repository.Implementations
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
