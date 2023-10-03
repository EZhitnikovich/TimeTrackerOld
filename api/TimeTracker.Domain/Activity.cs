namespace TimeTracker.Domain
{
    public class Activity: BaseEntity
    { // TODO: add user id
        public string Description { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; }
        public Project? Project { get; set; }
        public long StartInMilliseconds { get; set; }
        public long? EndInMilliseconds { get; set;}
    }
}
