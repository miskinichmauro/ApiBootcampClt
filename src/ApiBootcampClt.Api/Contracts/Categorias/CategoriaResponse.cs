namespace ApiBootcampClt.Api.Contracts.Categorias;

public sealed record CategoriaResponse(
    int Id,
    string Nombre,
    string? Descripcion,
    bool Estado
);
