using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain
{
    public class BaseEntity
    {
        [Key] public Guid Id { get; set; }
    }
}
