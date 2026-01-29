using ApiBootcampClt.Application.Categorias.Dtos;
using MediatR;

namespace ApiBootcampClt.Application.Categorias.Queries;

public sealed record GetCategoriaByIdQuery(int Id) : IRequest<CategoriaDto?>;
