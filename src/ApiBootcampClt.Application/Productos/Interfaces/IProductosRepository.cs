using ApiBootcampClt.Application.Productos.Dtos;
using ApiBootcampClt.Domain.Entities;

namespace ApiBootcampClt.Application.Productos.Interfaces;

public interface IProductosRepository
{
    Task<IReadOnlyList<ProductoDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductoDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> ExistsByCodigoAsync(string codigo, CancellationToken cancellationToken);
    Task<bool> ExistsByCodigoAsync(string codigo, int excludeId, CancellationToken cancellationToken);
    Task<ProductoDto> CreateAsync(Producto producto, CancellationToken cancellationToken);
    Task<ProductoDto?> UpdateAsync(Producto producto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
