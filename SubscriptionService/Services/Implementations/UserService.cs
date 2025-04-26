using SubscriptionService.Models;
using SubscriptionService.Repository.Abstractions;
using SubscriptionService.Services.Abstractions;

namespace SubscriptionService.Services.Implementations
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
