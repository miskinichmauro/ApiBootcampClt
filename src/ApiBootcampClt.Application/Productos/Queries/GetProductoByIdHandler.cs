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
    public Task<ProductoDto?> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Obteniendo el producto con id {IdProducto}", request.Id);
        return productosRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}