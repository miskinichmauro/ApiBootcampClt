using ApiBootcampClt.Application.Categorias.Dtos;
using ApiBootcampClt.Application.Categorias.Interfaces;
using ApiBootcampClt.Domain.Entities;
using ApiBootcampClt.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiBootcampClt.Infrastructure.Repositories.Categorias;

public sealed class CategoriasRepository(AppDbContext db) : ICategoriasRepository
{
    public async Task<IReadOnlyList<CategoriaDto>> GetAllAsync(CancellationToken cancellationToken)
        => await db.Categorias
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .Select(c => new CategoriaDto(
                c.Id,
                c.Nombre,
                c.Descripcion,
                c.Estado
            ))
            .ToListAsync(cancellationToken);

    public async Task<CategoriaDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await db.Categorias
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Select(c => new CategoriaDto(
                c.Id,
                c.Nombre,
                c.Descripcion,
                c.Estado
            ))
            .SingleOrDefaultAsync(cancellationToken);

    public async Task<CategoriaDto> CreateAsync(Categoria categoria, CancellationToken cancellationToken)
    {
        db.Categorias.Add(categoria);
        await db.SaveChangesAsync(cancellationToken);
        return (await GetByIdAsync(categoria.Id, cancellationToken))!;
    }

    public async Task<CategoriaDto?> UpdateAsync(Categoria categoria, CancellationToken cancellationToken)
    {
        var existing = await db.Categorias
            .SingleOrDefaultAsync(c => c.Id == categoria.Id, cancellationToken);

        if (existing is null)
            return null;

        existing.Nombre = categoria.Nombre;
        existing.Descripcion = categoria.Descripcion;
        existing.Estado = categoria.Estado;

        await db.SaveChangesAsync(cancellationToken);
        return await GetByIdAsync(existing.Id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var existing = await db.Categorias
            .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (existing is null)
            return false;

        db.Categorias.Remove(existing);
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        => await db.Categorias.AnyAsync(c => c.Id == id, cancellationToken);
}
