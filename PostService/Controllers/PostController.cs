using Microsoft.AspNetCore.Mvc;
using PostService.Dto;
using SubscriptionService.Models;
using SubscriptionService.Services.Abstractions;

namespace PostService.Controllers
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
                UserId = postDto.UserId,
                ChannelId = postDto.ChannelId,
                Title = postDto.Title,
                Content = postDto.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _postService.AddAsync(post);
            await _postService.Publish(post);

            return CreatedAtAction(nameof(CreatePost), new { id = post.Id }, post);
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetAllAsync();

            return Ok(posts);
        }
    }
}
