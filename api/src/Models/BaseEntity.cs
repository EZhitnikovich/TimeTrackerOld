using System.ComponentModel.DataAnnotations;

namespace TimeTrackerApi.Models
{
    public class BaseEntity
    {
        [Key] public int Id { get; set; }
    }
}
