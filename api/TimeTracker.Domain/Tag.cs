using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain
{
    public class Tag : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;

        public List<Activity> Activities { get; set; } = new();
    }
}
