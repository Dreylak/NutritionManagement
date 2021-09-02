using Common.Infrastructure.Implementation.Services;
using Common.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Common.Infrastructure.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
