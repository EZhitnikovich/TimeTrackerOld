using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Persistence
{
    public class TimeTrackerDbContext : DbContext, ITimeTrackerDbContext
    {
        public TimeTrackerDbContext(DbContextOptions<TimeTrackerDbContext> options)
            : base(options) { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
