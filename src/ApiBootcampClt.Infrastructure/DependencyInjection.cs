using ApiBootcampClt.Application.Categorias.Interfaces;
using ApiBootcampClt.Application.Productos.Interfaces;
using ApiBootcampClt.Infrastructure.Context;
using ApiBootcampClt.Infrastructure.Repositories.Categorias;
using ApiBootcampClt.Infrastructure.Repositories.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiBootcampClt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("ProductosDb");
        services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

        services.AddScoped<IProductosRepository, ProductosRepository>();
        services.AddScoped<ICategoriasRepository, CategoriasRepository>();

        return services;
    }
}
