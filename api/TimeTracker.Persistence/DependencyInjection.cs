using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Application.Interfaces;

namespace TimeTracker.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var conectionString = configuration["DbConnection"];
            services.AddDbContext<TimeTrackerDbContext>(options =>
            {
                options.UseSqlite(conectionString);
            });
            services.AddScoped<ITimeTrackerDbContext>(provider => provider.GetService<TimeTrackerDbContext>());
            return services;
        }
    }
}
