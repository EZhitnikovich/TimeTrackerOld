using System.ComponentModel.DataAnnotations;

namespace TimeTrackerApi.Models
{
    public class Tag: BaseEntity
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; } = string.Empty;
    }
}
