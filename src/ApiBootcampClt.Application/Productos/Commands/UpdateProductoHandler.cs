using ApiBootcampClt.Application.Categorias.Interfaces;
using ApiBootcampClt.Application.Productos.Dtos;
using ApiBootcampClt.Application.Productos.Interfaces;
using ApiBootcampClt.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiBootcampClt.Application.Productos.Commands;

public sealed class UpdateProductoHandler(
    ILogger<UpdateProductoHandler> logger,
    IProductosRepository productosRepository,
    ICategoriasRepository categoriasRepository
) : IRequestHandler<UpdateProductoCommand, ProductoDto?>
{
    public async Task<ProductoDto?> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Actualizando el producto con id {IdProducto}", request.Id);

        if (!await categoriasRepository.ExistsAsync(request.CategoriaId, cancellationToken))
            return null;

        var producto = new Producto
        {
            Id = request.Id,
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Precio = request.Precio,
            Activo = request.Activo,
            CategoriaId = request.CategoriaId,
            FechaActualizacion = DateTime.UtcNow,
            CantidadStock = request.CantidadStock
        };

        return await productosRepository.UpdateAsync(producto, cancellationToken);
    }
}
