using ApiBootcampClt.Application.Productos.Dtos;
using ApiBootcampClt.Application.Productos.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiBootcampClt.Application.Productos.Queries;

public class GetAllProductosQueryHandler(
    ILogger<GetAllProductosQueryHandler> logger,
    IProductosRepository productosRepository
) : IRequestHandler<GetAllProductosQuery, IReadOnlyList<ProductoDto>>
{
    public async Task<IReadOnlyList<ProductoDto>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Obteniendo todos los productos");
        return await productosRepository.GetAllAsync(cancellationToken);
    }
}