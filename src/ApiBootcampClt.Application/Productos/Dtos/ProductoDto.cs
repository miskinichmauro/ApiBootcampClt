namespace ApiBootcampClt.Application.Productos.Dtos;

public sealed record ProductoDto(
    int Id,
    string Codigo,
    string Nombre,
    string? Descripcion,
    decimal Precio,
    bool Activo,
    int CategoriaId,
    string CategoriaNombre,
    DateTime FechaCreacion,
    DateTime? FechaActualizacion,
    int CantidadStock
);