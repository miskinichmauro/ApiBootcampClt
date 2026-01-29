using ApiBootcampClt.Application.Categorias.Dtos;
using ApiBootcampClt.Application.Categorias.Interfaces;
using ApiBootcampClt.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiBootcampClt.Application.Categorias.Commands;

public sealed class CreateCategoriaHandler(
    ILogger<CreateCategoriaHandler> logger,
    ICategoriasRepository categoriasRepository
) : IRequestHandler<CreateCategoriaCommand, CategoriaDto>
{
    public async Task<CategoriaDto> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creando una nueva categoria");

        var categoria = new Categoria
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Estado = request.Estado
        };

        return await categoriasRepository.CreateAsync(categoria, cancellationToken);
    }
}
