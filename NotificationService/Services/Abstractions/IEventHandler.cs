using NotificationSystem.Contracts;

namespace NotificationSystem.Services.Abstractions
{
    public interface IEventHandler
    {
        public Task HandleAsync(MessageEnvelope envelope);
    }
}
