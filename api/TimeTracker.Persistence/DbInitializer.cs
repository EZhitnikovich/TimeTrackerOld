namespace TimeTracker.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(TimeTrackerDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
