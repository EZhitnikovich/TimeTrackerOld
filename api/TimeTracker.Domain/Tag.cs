using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain
{
    public class Tag: BaseEntity
    { // TODO: add user id
        [Required]
        [MinLength(1)]
        public string Title { get; set; } = string.Empty;
    }
}
