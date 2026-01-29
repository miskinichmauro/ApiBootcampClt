using ApiBootcampClt.Application.Categorias.Interfaces;
using ApiBootcampClt.Application.Productos.Dtos;
using ApiBootcampClt.Application.Productos.Interfaces;
using ApiBootcampClt.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiBootcampClt.Application.Productos.Commands;

public sealed class CreateProductoHandler(
    ILogger<CreateProductoHandler> logger,
    IProductosRepository productosRepository,
    ICategoriasRepository categoriasRepository
) : IRequestHandler<CreateProductoCommand, ProductoDto?>
{
    public async Task<ProductoDto?> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creando un nuevo producto");

        if (!await categoriasRepository.ExistsAsync(request.CategoriaId, cancellationToken))
            return null;

        var producto = new Producto
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Precio = request.Precio,
            Activo = request.Activo,
            CategoriaId = request.CategoriaId,
            FechaCreacion = DateTime.UtcNow,
            FechaActualizacion = null,
            CantidadStock = request.CantidadStock
        };

        return await productosRepository.CreateAsync(producto, cancellationToken);
    }
}
