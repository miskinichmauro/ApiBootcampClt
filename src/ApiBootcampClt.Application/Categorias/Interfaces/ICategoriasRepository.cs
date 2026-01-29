using ApiBootcampClt.Application.Categorias.Dtos;
using ApiBootcampClt.Domain.Entities;

namespace ApiBootcampClt.Application.Categorias.Interfaces;

public interface ICategoriasRepository
{
    Task<IReadOnlyList<CategoriaDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<CategoriaDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<CategoriaDto> CreateAsync(Categoria categoria, CancellationToken cancellationToken);
    Task<CategoriaDto?> UpdateAsync(Categoria categoria, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
}
