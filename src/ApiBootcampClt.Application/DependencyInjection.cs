using Microsoft.Extensions.DependencyInjection;

namespace ApiBootcampClt.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(IAssemblyMarker).Assembly);
        });

        return services;
    }
}