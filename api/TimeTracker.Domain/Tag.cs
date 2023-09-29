using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain
{
    public class Tag: BaseEntity
    {
        public Guid UserId { get; set; }
        [Required]
        [MinLength(1)]
        public string Title { get; set; } = string.Empty;
    }
}
