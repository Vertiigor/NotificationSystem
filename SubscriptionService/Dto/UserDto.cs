namespace SubscriptionService.Dto
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Subscriptions { get; set; } = new List<string>();
    }
}
