using ApiBootcampClt.Api.Contracts.Productos;
using ApiBootcampClt.Application.Productos.Dtos;

namespace ApiBootcampClt.Api.Mappings;

public static class ProductoMappings
{
    public static ProductoResponse ToResponse(this ProductoDto dto)
        => new(
            dto.Id,
            dto.Codigo,
            dto.Nombre,
            dto.Descripcion,
            dto.Precio,
            dto.Activo,
            dto.CategoriaId,
            dto.CategoriaNombre,
            dto.FechaCreacion,
            dto.FechaActualizacion,
            dto.CantidadStock
        );
}
