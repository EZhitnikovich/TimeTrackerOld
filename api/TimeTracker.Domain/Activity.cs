namespace TimeTracker.Domain
{
    public class Activity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Tag>? Tags { get; set; }
        public Project? Project { get; set; }
        public long StartInMilliseconds { get; set; }
        public long? EndInMilliseconds { get; set; }
    }
}
