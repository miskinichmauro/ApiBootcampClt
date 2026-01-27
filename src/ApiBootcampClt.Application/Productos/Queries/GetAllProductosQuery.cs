using ApiBootcampClt.Application.Productos.Dtos;
using MediatR;

namespace ApiBootcampClt.Application.Productos.Queries;

public sealed record GetAllProductosQuery : IRequest<IReadOnlyList<ProductoDto>>;
