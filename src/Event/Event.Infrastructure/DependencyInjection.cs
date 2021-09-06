using Event.Infrastructure.Persistance;
using Event.Logic.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEventInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<EventDbContext>(options =>
                    options.UseInMemoryDatabase("EventServiceDb"));
            }
            else
            {
                services.AddDbContext<EventDbContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(EventDbContext).Assembly.FullName)));
            }

            services.AddScoped<IEventDbContext>(provider => provider.GetService<EventDbContext>());

            return services;
        }
    }
}
