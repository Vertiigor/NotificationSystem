using NotificationService.Models;
using NotificationService.Repository.Abstractions;
using NotificationService.Services.Abstractions;

namespace NotificationService.Services.Implementations
{
    public class ChannelService : Service<Channel>, IChannelService
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IUserRepository _userRepository;

        public ChannelService(IChannelRepository channelRepository, IUserRepository userRepository) : base(channelRepository)
        {
            _channelRepository = channelRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersSubscribedTo(string channelId)
        {
            var users = await _userRepository.GetAllAsync();
            var subscribedUsers = users
                .Where(user => user.Subscriptions.Any(channel => channel.Id == channelId))
                .ToList();

            return subscribedUsers;
        }

        public async Task<bool> IsUserSubscribedToChannel(string userId, string channelId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            return user.Subscriptions.Any(channel => channel.Id == channelId);
        }

        public async Task SubscribeToChannel(string userId, string channelId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var channel = await _channelRepository.GetByIdAsync(channelId);

            if (user == null || channel == null)
            {
                throw new ArgumentException("User or Channel not found");
            }

            if (!user.Subscriptions.Any(c => c.Id == channelId))
            {
                user.Subscriptions.Add(channel);
                await _userRepository.UpdateAsync(user);
            }
        }

        public async Task UnsubscribeFromChannel(string userId, string channelId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var channel = await _channelRepository.GetByIdAsync(channelId);

            if (user == null || channel == null)
            {
                throw new ArgumentException("User or Channel not found");
            }

            if (user.Subscriptions.Any(c => c.Id == channelId))
            {
                user.Subscriptions.Remove(channel);
                await _userRepository.UpdateAsync(user);
            }
        }
    }
}
