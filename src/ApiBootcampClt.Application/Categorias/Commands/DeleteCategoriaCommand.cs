using MediatR;

namespace ApiBootcampClt.Application.Categorias.Commands;

public sealed record DeleteCategoriaCommand(int Id) : IRequest<bool>;
