using Microsoft.AspNetCore.Mvc;
using NotificationService.Contracts;
using NotificationService.Dto;
using NotificationService.Models;
using NotificationService.Services.Abstractions;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostDto postDto)
        {
            if (postDto == null)
            {
                return BadRequest("Post data is null");
            }

            var post = new Post
            {
                Id = Guid.NewGuid().ToString(),
                UserId = postDto.UserId,
                ChannelId = postDto.ChannelId,
                Title = postDto.Title,
                Content = postDto.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Publish the post creation event
            var postCreatedEvent = new PostCreatedEvent
            {
                PostId = post.Id,
                Title = post.Title,
                ChannelId = postDto.ChannelId,
                CreatedAt = DateTime.UtcNow
            };

            await _postService.AddAsync(post);
            await _postService.Publish("PostCreated", postCreatedEvent);

            return CreatedAtAction(nameof(CreatePost), new { id = post.Id }, post);
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetAllAsync();

            return Ok(posts);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            var post = await _postService.GetByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            // Publish the post deletion event
            var postDeletedEvent = new PostDeletedEvent
            {
                PostId = post.Id,
                DeletedAt = DateTime.UtcNow
            };

            await _postService.DeleteAsync(id);
            await _postService.Publish("PostDeleted", postDeletedEvent);

            return NoContent();
        }
    }
}
