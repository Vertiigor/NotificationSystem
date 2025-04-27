using NotificationService.Models;
using NotificationService.Repository.Abstractions;
using NotificationService.Services.Abstractions;

namespace NotificationService.Services.Implementations
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(string userId)
        {
            return await _userRepository.GetSubscribedChannelsAsync(userId);
        }
    }
}
