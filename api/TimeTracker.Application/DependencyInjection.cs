using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TimeTracker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // TODO: mb smth wrong
            return services;
        }
    }
}
