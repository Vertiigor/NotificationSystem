namespace SubscriptionService.Contracts
{
    public class PostCreatedEvent
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string TopicName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
