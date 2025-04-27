using NotificationService.Contracts;
using NotificationService.Services.Abstractions;

namespace NotificationService.Services.EventHandlers
{
    public class PostCreatedHandler : IEventHandler
    {
        private readonly IUserService _userService;
        private readonly IChannelService _channelService;

        public PostCreatedHandler(IUserService userService, IChannelService channelService)
        {
            _userService = userService;
            _channelService = channelService;
        }

        public async Task HandleAsync(MessageEnvelope envelope)
        {
            var postCreatedEvent = envelope.GetPayload<PostCreatedEvent>(); ;
            var users = await _channelService.GetUsersSubscribedTo(postCreatedEvent.ChannelId);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.White;
            foreach (var user in users)
            {
                Console.WriteLine($"📨 Notifying {user.Email} about new post '{postCreatedEvent.Title}'");
            }
            Console.ResetColor();
        }
    }
}
