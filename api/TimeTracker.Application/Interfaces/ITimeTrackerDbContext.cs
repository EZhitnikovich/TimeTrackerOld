using Microsoft.EntityFrameworkCore;
using TimeTracker.Domain;

namespace TimeTracker.Application.Interfaces
{
    public interface ITimeTrackerDbContext
    {
        DbSet<Activity> Activities { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Tag> Tags { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
