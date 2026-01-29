namespace ApiBootcampClt.Api.Contracts.Productos;

public sealed record ProductoResponse(
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
