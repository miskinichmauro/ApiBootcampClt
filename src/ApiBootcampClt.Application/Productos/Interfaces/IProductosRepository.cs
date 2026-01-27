using ApiBootcampClt.Application.Productos.Dtos;

namespace ApiBootcampClt.Application.Productos.Interfaces;

public interface IProductosRepository
{
    Task<IReadOnlyList<ProductoDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductoDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
}