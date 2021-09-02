using Common.Behaviors;
using Common.Mappings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Customer.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly())));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
