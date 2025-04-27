namespace PostService.Contracts
{
    public class PostCreatedEvent
    {
        public string PostId { get; set; }
        public string Title { get; set; }
        public string ChannelId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
