using ApiBootcampClt.Application.Categorias.Dtos;
using ApiBootcampClt.Application.Categorias.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiBootcampClt.Application.Categorias.Queries;

public sealed class GetAllCategoriasHandler(
    ILogger<GetAllCategoriasHandler> logger,
    ICategoriasRepository categoriasRepository
) : IRequestHandler<GetAllCategoriasQuery, IReadOnlyList<CategoriaDto>>
{
    public async Task<IReadOnlyList<CategoriaDto>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Obteniendo todas las categorias");
        return await categoriasRepository.GetAllAsync(cancellationToken);
    }
}
