using Microsoft.AspNetCore.Identity;

namespace SubscriptionService.Models
{
    public class User : IdentityUser
    {
        public List<Channel> Subscriptions { get; set; } = new List<Channel>();
    }
}
