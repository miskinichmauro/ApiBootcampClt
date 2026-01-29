using ApiBootcampClt.Application.Categorias.Dtos;
using MediatR;

namespace ApiBootcampClt.Application.Categorias.Commands;

public sealed record UpdateCategoriaCommand(
    int Id,
    string Nombre,
    string? Descripcion,
    bool Estado
) : IRequest<CategoriaDto?>;
