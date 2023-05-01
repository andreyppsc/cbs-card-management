using CM.Api.Application.Commands;
using CM.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CM.Api.Controllers;

[ApiController]
[Route("cards")]
public class CardsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CardsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{cardId:guid}")]
    public async Task<IActionResult> Get(Guid cardId, CancellationToken cancellationToken = default)
    {
        var card = await _mediator.Send(new GetCard(cardId), cancellationToken);
        return Ok(card);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCard request, CancellationToken cancellationToken = default)
    {
        var card = await _mediator.Send(request, cancellationToken);
        return Ok(card);
    }
}