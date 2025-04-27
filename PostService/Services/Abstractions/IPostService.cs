using NotificationSystem.Models;

namespace NotificationSystem.Services.Abstractions
{
    public interface IPostService : IService<Post>
    {
        public Task Publish<T>(string eventType, T payload);
    }
}
