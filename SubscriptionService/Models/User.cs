using Microsoft.AspNetCore.Identity;

namespace PostService.Models
{
    public class User : IdentityUser
    {
        public List<Channel> Subscriptions { get; set; } = new List<Channel>();
    }
}
