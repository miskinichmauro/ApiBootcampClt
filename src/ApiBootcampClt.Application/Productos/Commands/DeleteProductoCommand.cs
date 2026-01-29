using MediatR;

namespace ApiBootcampClt.Application.Productos.Commands;

public sealed record DeleteProductoCommand(int Id) : IRequest<bool>;
