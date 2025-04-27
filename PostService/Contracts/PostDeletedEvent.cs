namespace PostService.Contracts
{
    public class PostDeletedEvent
    {
        public string PostId { get; set; } = string.Empty;
        public string ChannelId { get; set; } = string.Empty;
        public DateTime DeletedAt { get; set; } = DateTime.UtcNow;
    }
}
