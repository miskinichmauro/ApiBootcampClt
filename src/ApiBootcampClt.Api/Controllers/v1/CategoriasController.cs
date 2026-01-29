using ApiBootcampClt.Api.Contracts.Categorias;
using ApiBootcampClt.Api.Mappings;
using ApiBootcampClt.Application.Categorias.Commands;
using ApiBootcampClt.Application.Categorias.Queries;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiBootcampClt.Api.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("v1/api/categorias")]
[ProducesResponseType(typeof(CategoriaResponse), StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
public class CategoriasController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CategoriaResponse>> GetAll(CancellationToken cancellationToken)
    {
        var categorias = await mediator.Send(new GetAllCategoriasQuery(), cancellationToken);
        return Ok(categorias.Select(categoria => categoria.ToResponse()));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaResponse>> GetById(int id, CancellationToken cancellationToken)
    {
        var categoria = await mediator.Send(new GetCategoriaByIdQuery(id), cancellationToken);
        return categoria is null ? NotFound() : Ok(categoria.ToResponse());
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaResponse>> Create([FromBody] CategoriaCreateRequest request, CancellationToken cancellationToken)
    {
        var categoria = await mediator.Send(
            new CreateCategoriaCommand(request.Nombre, request.Descripcion, request.Estado),
            cancellationToken
        );

        return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria.ToResponse());
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaResponse>> Update(int id, [FromBody] CategoriaUpdateRequest request, CancellationToken cancellationToken)
    {
        var categoria = await mediator.Send(
            new UpdateCategoriaCommand(id, request.Nombre, request.Descripcion, request.Estado),
            cancellationToken
        );

        return categoria is null ? NotFound() : Ok(categoria.ToResponse());
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaResponse>> Patch(int id, [FromBody] CategoriaPatchRequest request, CancellationToken cancellationToken)
    {
        var existing = await mediator.Send(new GetCategoriaByIdQuery(id), cancellationToken);
        if (existing is null)
            return NotFound();

        var categoria = await mediator.Send(
            new UpdateCategoriaCommand(
                id,
                request.Nombre ?? existing.Nombre,
                request.Descripcion ?? existing.Descripcion,
                request.Estado ?? existing.Estado
            ),
            cancellationToken
        );

        return categoria is null ? NotFound() : Ok(categoria.ToResponse());
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaResponse>> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCategoriaCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
