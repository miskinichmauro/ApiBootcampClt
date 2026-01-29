using ApiBootcampClt.Api.Contracts.Common;
using ApiBootcampClt.Api.Contracts.Productos;
using ApiBootcampClt.Api.Mappings;
using ApiBootcampClt.Application.Productos.Commands;
using ApiBootcampClt.Application.Productos.Queries;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiBootcampClt.Api.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("v1/api/productos")]
[ProducesResponseType(typeof(ProductoResponse), StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
public class ProductosController(IMediator mediator) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult<ProductoResponse>> GetAll(CancellationToken cancellationToken)
    {
        var productos = await mediator.Send(new GetAllProductosQuery(), cancellationToken);
        return Ok(productos.Select(producto => producto.ToResponse()));
    }

    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoResponse>> GetById(int id, CancellationToken cancellationToken)
    {
        var producto = await mediator.Send(new GetProductoByIdQuery(id), cancellationToken);
        return producto is null
            ? NotFound(new ErrorResponse(StatusCodes.Status404NotFound, $"Producto con id {id} no encontrado"))
            : Ok(producto.ToResponse());
    }

    [HttpPost]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoResponse>> Create([FromBody] ProductoCreateRequest request, CancellationToken cancellationToken)
    {
        var producto = await mediator.Send(
            new CreateProductoCommand(
                request.Codigo,
                request.Nombre,
                request.Descripcion,
                request.Precio,
                request.Activo,
                request.CategoriaId,
                request.CantidadStock
            ),
            cancellationToken
        );

        if (producto is null)
            return NotFound(new ErrorResponse(
                StatusCodes.Status404NotFound,
                $"Categoria con id {request.CategoriaId} no encontrada"
            ));

        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto.ToResponse());
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoResponse>> Update(int id, [FromBody] ProductoUpdateRequest request, CancellationToken cancellationToken)
    {
        var producto = await mediator.Send(
            new UpdateProductoCommand(
                id,
                request.Codigo,
                request.Nombre,
                request.Descripcion,
                request.Precio,
                request.Activo,
                request.CategoriaId,
                request.CantidadStock
            ),
            cancellationToken
        );

        return producto is null
            ? NotFound(new ErrorResponse(StatusCodes.Status404NotFound, $"Producto con id {id} no encontrado"))
            : Ok(producto.ToResponse());
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoResponse>> Patch(int id, [FromBody] ProductoPatchRequest request, CancellationToken cancellationToken)
    {
        var existing = await mediator.Send(new GetProductoByIdQuery(id), cancellationToken);
        if (existing is null)
            return NotFound(new ErrorResponse(StatusCodes.Status404NotFound, $"Producto con id {id} no encontrado"));

        var producto = await mediator.Send(
            new UpdateProductoCommand(
                id,
                request.Codigo ?? existing.Codigo,
                request.Nombre ?? existing.Nombre,
                request.Descripcion ?? existing.Descripcion,
                request.Precio ?? existing.Precio,
                request.Activo ?? existing.Activo,
                request.CategoriaId ?? existing.CategoriaId,
                request.CantidadStock ?? existing.CantidadStock
            ),
            cancellationToken
        );

        return producto is null
            ? NotFound(new ErrorResponse(StatusCodes.Status404NotFound, $"Producto con id {id} no encontrado"))
            : Ok(producto.ToResponse());
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoResponse>> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteProductoCommand(id), cancellationToken);
        return deleted
            ? NoContent()
            : NotFound(new ErrorResponse(StatusCodes.Status404NotFound, $"Producto con id {id} no encontrado"));
    }
}
