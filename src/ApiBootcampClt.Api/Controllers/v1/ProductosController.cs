using ApiBootcampClt.Application.Productos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiBootcampClt.Api.Controllers.v1;

[ApiController]
[Route("v1/api/productos")]
public class ProductosController(IMediator mediator) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var productos = await mediator.Send(new GetAllProductosQuery(), cancellationToken);
        return Ok(productos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var producto = await mediator.Send(new GetProductoByIdQuery(id), cancellationToken);
        return producto is null ? NotFound() : Ok(producto);
    }
}