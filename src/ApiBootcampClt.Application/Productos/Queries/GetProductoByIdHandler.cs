using ApiBootcampClt.Application.Productos.Dtos;
using ApiBootcampClt.Application.Productos.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiBootcampClt.Application.Productos.Queries;

public sealed class GetProductoByIdHandler(
    ILogger<GetProductoByIdHandler> logger,
    IProductosRepository productosRepository
) : IRequestHandler<GetProductoByIdQuery, ProductoDto?>
{
    public async Task<ProductoDto?> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Obteniendo producto con id {ProductoId}", request.Id);
        var producto = await productosRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (producto == null)
        {
            logger.LogWarning("Producto con id {ProductoId} no encontrado", request.Id);
        }
        return producto;
    }
}