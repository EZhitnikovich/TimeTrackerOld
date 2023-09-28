using System.ComponentModel.DataAnnotations;

namespace TimeTrackerApi.Models
{
    public class Project: BaseEntity
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; } = string.Empty;
    }
}
