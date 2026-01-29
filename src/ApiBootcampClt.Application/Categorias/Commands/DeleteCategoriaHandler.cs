using ApiBootcampClt.Application.Categorias.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiBootcampClt.Application.Categorias.Commands;

public sealed class DeleteCategoriaHandler(
    ILogger<DeleteCategoriaHandler> logger,
    ICategoriasRepository categoriasRepository
) : IRequestHandler<DeleteCategoriaCommand, bool>
{
    public async Task<bool> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Eliminando la categoria con id {IdCategoria}", request.Id);
        return await categoriasRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
