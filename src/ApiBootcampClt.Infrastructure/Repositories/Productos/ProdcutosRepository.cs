using ApiBootcampClt.Application.Productos.Dtos;
using ApiBootcampClt.Application.Productos.Interfaces;
using ApiBootcampClt.Domain.Entities;
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

    public async Task<ProductoDto> CreateAsync(Producto producto, CancellationToken cancellationToken)
    {
        db.Productos.Add(producto);
        await db.SaveChangesAsync(cancellationToken);
        return (await GetByIdAsync(producto.Id, cancellationToken))!;
    }

    public async Task<ProductoDto?> UpdateAsync(Producto producto, CancellationToken cancellationToken)
    {
        var existing = await db.Productos
            .SingleOrDefaultAsync(p => p.Id == producto.Id, cancellationToken);

        if (existing is null)
            return null;

        existing.Codigo = producto.Codigo;
        existing.Nombre = producto.Nombre;
        existing.Descripcion = producto.Descripcion;
        existing.Precio = producto.Precio;
        existing.Activo = producto.Activo;
        existing.CategoriaId = producto.CategoriaId;
        existing.FechaActualizacion = producto.FechaActualizacion;
        existing.CantidadStock = producto.CantidadStock;

        await db.SaveChangesAsync(cancellationToken);
        return await GetByIdAsync(existing.Id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var existing = await db.Productos
            .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (existing is null)
            return false;

        db.Productos.Remove(existing);
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
