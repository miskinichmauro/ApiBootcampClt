namespace ApiBootcampClt.Application.Categorias.Dtos;

public sealed record CategoriaDto(
    int Id,
    string Nombre,
    string? Descripcion,
    bool Estado
);
