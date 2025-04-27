using Microsoft.AspNetCore.Mvc;
using SubscriptionService.Dto;
using SubscriptionService.Models;
using SubscriptionService.Services.Abstractions;

namespace SubscriptionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChannels()
        {
            var channels = await _channelService.GetAllAsync();

            if (channels == null || !channels.Any())
            {
                return NotFound("No channels found.");
            }

            return Ok(channels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChannelById(string id)
        {
            var channel = await _channelService.GetByIdAsync(id);

            if (channel == null)
            {
                return NotFound($"Channel with ID {id} not found.");
            }

            return Ok(channel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChannel([FromBody] ChannelDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Channel data is required.");
            }

            var channel = new Channel
            {
                Id = Guid.NewGuid().ToString(),
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _channelService.AddAsync(channel);

            return CreatedAtAction(nameof(GetChannelById), new { id = channel.Id }, channel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChannel(string id, [FromBody] ChannelDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Channel data is required.");
            }

            var channel = await _channelService.GetByIdAsync(id);

            if (channel == null)
            {
                return NotFound($"Channel with ID {id} not found.");
            }

            channel.Name = dto.Name;
            channel.Description = dto.Description;
            channel.UpdatedAt = DateTime.UtcNow;

            await _channelService.UpdateAsync(channel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChannel(string id)
        {
            var channel = await _channelService.GetByIdAsync(id);

            if (channel == null)
            {
                return NotFound($"Channel with ID {id} not found.");
            }

            await _channelService.DeleteAsync(id);

            return NoContent();
        }
    }
}
