using PostService.Contracts;
using PostService.Models;

namespace PostService.Services.Abstractions
{
    public interface IPostService : IService<Post>
    {
        public Task Publish<T>(string eventType, T payload);
    }
}
