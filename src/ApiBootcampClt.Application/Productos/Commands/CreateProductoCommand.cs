using ApiBootcampClt.Application.Productos.Dtos;
using MediatR;

namespace ApiBootcampClt.Application.Productos.Commands;

public sealed record CreateProductoCommand(
    string Codigo,
    string Nombre,
    string? Descripcion,
    decimal Precio,
    bool Activo,
    int CategoriaId,
    int CantidadStock
) : IRequest<ProductoDto?>;
