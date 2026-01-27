using ApiBootcampClt.Application.Productos.Dtos;
using ApiBootcampClt.Application.Productos.Interfaces;
using ApiBootcampClt.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiBootcampClt.Infrastructure.Repositories.Productos;

public class ProdcutosRepository(AppDbContext db) : IProductosRepository
{
    public async Task<IReadOnlyList<ProductoDto>> GetAllAsync(CancellationToken cancellationToken)
        => await db.Productos
            .AsNoTracking()
            .Include(p => p.Categoria)
            .OrderBy(p => p.Id)
            .Select(p => new ProductoDto(
                p.Id,
                p.Codigo,
                p.Nombre,
                p.Descripcion,
                p.Precio,
                p.Activo,
                p.CategoriaId,
                p.Categoria.Nombre,
                p.FechaCreacion,
                p.FechaActualizacion,
                p.CantidadStock
            ))
            .ToListAsync(cancellationToken);

    public async Task<ProductoDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await db.Productos
            .AsNoTracking()
            .Include(p => p.Categoria)
            .Where(p => p.Id == id)
            .Select(p => new ProductoDto(
                p.Id,
                p.Codigo,
                p.Nombre,
                p.Descripcion,
                p.Precio,
                p.Activo,
                p.CategoriaId,
                p.Categoria.Nombre,
                p.FechaCreacion,
                p.FechaActualizacion,
                p.CantidadStock
            ))
            .SingleOrDefaultAsync(cancellationToken);
    }
}