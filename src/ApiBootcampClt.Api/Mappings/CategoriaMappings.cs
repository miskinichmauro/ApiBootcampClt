using ApiBootcampClt.Api.Contracts.Categorias;
using ApiBootcampClt.Application.Categorias.Dtos;

namespace ApiBootcampClt.Api.Mappings;

public static class CategoriaMappings
{
    public static CategoriaResponse ToResponse(this CategoriaDto dto)
        => new(
            dto.Id,
            dto.Nombre,
            dto.Descripcion,
            dto.Estado
        );
}
