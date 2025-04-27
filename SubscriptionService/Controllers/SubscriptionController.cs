using Microsoft.AspNetCore.Mvc;
using NotificationService.Dto;
using NotificationService.Services.Abstractions;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public SubscriptionController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] SubscriptionDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Channel ID cannot be null or empty.");
            }
            await _channelService.SubscribeToChannel(dto.UserId, dto.ChannelId);

            return Ok("Subscribed successfully.");
        }

        [HttpPost("unsubscribe")]
        public async Task<IActionResult> Unsubscribe([FromBody] SubscriptionDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Channel ID cannot be null or empty.");
            }

            await _channelService.UnsubscribeFromChannel(dto.ChannelId, dto.UserId);

            return Ok("Unsubscribed successfully.");
        }
    }
}
