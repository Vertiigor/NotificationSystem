using NotificationService.Contracts;
using NotificationService.Services.Abstractions;

namespace NotificationService.Services.EventHandlers
{
    public class PostDeletedHandler : IEventHandler
    {
        private readonly IUserService _userService;
        private readonly IChannelService _channelService;

        public PostDeletedHandler(IUserService userService, IChannelService channelService)
        {
            _userService = userService;
            _channelService = channelService;
        }
        public async Task HandleAsync(MessageEnvelope envelope)
        {
            var postDeletedEvent = envelope.GetPayload<PostDeletedEvent>();
            var users = await _channelService.GetUsersSubscribedTo(postDeletedEvent.ChannelId);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            foreach (var user in users)
            {
                Console.WriteLine($"📨 Notifying {user.Email} about post '{postDeletedEvent.PostId}' deletion");
            }
            Console.ResetColor();
        }
    } 
}
