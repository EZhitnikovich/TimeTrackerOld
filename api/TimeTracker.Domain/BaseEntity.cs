using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain
{
    public class BaseEntity
    {
        [Key] public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
