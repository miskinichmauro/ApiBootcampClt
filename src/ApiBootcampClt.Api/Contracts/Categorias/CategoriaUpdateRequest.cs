namespace ApiBootcampClt.Api.Contracts.Categorias;

public sealed record CategoriaUpdateRequest(
    string Nombre,
    string? Descripcion,
    bool Estado
);
