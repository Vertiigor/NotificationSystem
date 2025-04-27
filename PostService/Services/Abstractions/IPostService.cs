using NotificationService.Models;

namespace NotificationService.Services.Abstractions
{
    public interface IPostService : IService<Post>
    {
        public Task Publish<T>(string eventType, T payload);
    }
}
