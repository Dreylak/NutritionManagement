using Customer.Infrastructure.Persistance;
using Customer.Logic.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Customer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomerInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<CustomerDbContext>(options =>
                    options.UseInMemoryDatabase("CustomerServiceDb"));
            }
            else
            {
                services.AddDbContext<CustomerDbContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(CustomerDbContext).Assembly.FullName)));
            }

            services.AddScoped<ICustomerDbContext>(provider => provider.GetService<CustomerDbContext>());

            return services;
        }
    }
}
