namespace ApiBootcampClt.Api.Contracts.Productos;

public sealed record ProductoUpdateRequest(
    string Codigo,
    string Nombre,
    string? Descripcion,
    decimal Precio,
    bool Activo,
    int CategoriaId,
    int CantidadStock
);
