using ApiBootcampClt.Application.Categorias.Dtos;
using MediatR;

namespace ApiBootcampClt.Application.Categorias.Commands;

public sealed record CreateCategoriaCommand(
    string Nombre,
    string? Descripcion,
    bool Estado
) : IRequest<CategoriaDto>;
