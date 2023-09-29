using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain
{
    public class Tag: BaseEntity
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; } = string.Empty;
    }
}
