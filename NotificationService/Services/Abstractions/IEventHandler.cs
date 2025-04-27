using NotificationService.Contracts;

namespace NotificationService.Services.Abstractions
{
    public interface IEventHandler
    {
        public Task HandleAsync(MessageEnvelope envelope);
    }
}
