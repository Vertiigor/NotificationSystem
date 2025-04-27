using PostService.Models;
using PostService.Repository.Abstractions;
using PostService.Services.Abstractions;

namespace PostService.Services.Implementations
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
