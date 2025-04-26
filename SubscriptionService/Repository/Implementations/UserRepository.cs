using SubscriptionService.Data;
using SubscriptionService.Models;
using SubscriptionService.Repository.Abstractions;

namespace SubscriptionService.Repository.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
