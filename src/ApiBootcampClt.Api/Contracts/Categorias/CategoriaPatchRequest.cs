namespace ApiBootcampClt.Api.Contracts.Categorias;

public sealed record CategoriaPatchRequest(
    string? Nombre,
    string? Descripcion,
    bool? Estado
);
