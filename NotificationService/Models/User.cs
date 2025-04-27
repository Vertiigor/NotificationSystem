using Microsoft.AspNetCore.Identity;

namespace NotificationSystem.Models
{
    public class User : IdentityUser
    {
        public List<Channel> Subscriptions { get; set; } = new List<Channel>();
    }
}
