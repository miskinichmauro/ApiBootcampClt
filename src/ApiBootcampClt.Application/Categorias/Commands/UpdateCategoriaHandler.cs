using ApiBootcampClt.Application.Categorias.Dtos;
using ApiBootcampClt.Application.Categorias.Interfaces;
using ApiBootcampClt.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiBootcampClt.Application.Categorias.Commands;

public sealed class UpdateCategoriaHandler(
    ILogger<UpdateCategoriaHandler> logger,
    ICategoriasRepository categoriasRepository
) : IRequestHandler<UpdateCategoriaCommand, CategoriaDto?>
{
    public async Task<CategoriaDto?> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Actualizando la categoria con id {IdCategoria}", request.Id);

        var categoria = new Categoria
        {
            Id = request.Id,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Estado = request.Estado
        };

        return await categoriasRepository.UpdateAsync(categoria, cancellationToken);
    }
}
