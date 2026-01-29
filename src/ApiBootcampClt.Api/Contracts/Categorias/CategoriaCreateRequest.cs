namespace ApiBootcampClt.Api.Contracts.Categorias;

public sealed record CategoriaCreateRequest(
    string Nombre,
    string? Descripcion,
    bool Estado
);
