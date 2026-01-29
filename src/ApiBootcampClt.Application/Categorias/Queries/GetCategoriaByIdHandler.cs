using ApiBootcampClt.Application.Categorias.Dtos;
using ApiBootcampClt.Application.Categorias.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiBootcampClt.Application.Categorias.Queries;

public sealed class GetCategoriaByIdHandler(
    ILogger<GetCategoriaByIdHandler> logger,
    ICategoriasRepository categoriasRepository
) : IRequestHandler<GetCategoriaByIdQuery, CategoriaDto?>
{
    public async Task<CategoriaDto?> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Obteniendo la categoria con id {IdCategoria}", request.Id);
        return await categoriasRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
