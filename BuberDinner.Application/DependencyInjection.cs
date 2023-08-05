using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AppApplication(this IServiceCollection services)
    {
        // NOTE: https://github.com/jbogard/MediatR/wiki/Migration-Guide-11.x-to-12.0#service-registration-through-configuration-object-exclusively
        services.AddMediatR(cfg =>  cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;
    }
}
