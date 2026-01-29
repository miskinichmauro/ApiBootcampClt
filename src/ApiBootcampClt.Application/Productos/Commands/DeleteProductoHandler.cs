using ApiBootcampClt.Application.Productos.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiBootcampClt.Application.Productos.Commands;

public sealed class DeleteProductoHandler(
    ILogger<DeleteProductoHandler> logger,
    IProductosRepository productosRepository
) : IRequestHandler<DeleteProductoCommand, bool>
{
    public async Task<bool> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Eliminando el producto con id {IdProducto}", request.Id);
        return await productosRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
