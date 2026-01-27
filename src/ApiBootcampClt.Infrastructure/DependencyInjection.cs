using ApiBootcampClt.Application.Productos.Interfaces;
using ApiBootcampClt.Infrastructure.Context;
using ApiBootcampClt.Infrastructure.Repositories.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiBootcampClt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var cs = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(cs));

        services.AddScoped<IProductosRepository, ProdcutosRepository>();

        return services;
    }
}