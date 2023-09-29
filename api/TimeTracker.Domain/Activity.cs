namespace TimeTracker.Domain
{
    public class Activity: BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; }
        public Project? Project { get; set; }
        public int StartInMilliseconds { get; set; }
        public int? EndInMilliseconds { get; set;}
    }
}
