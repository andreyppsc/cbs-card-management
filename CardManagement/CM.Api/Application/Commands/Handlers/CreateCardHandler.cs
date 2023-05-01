using CM.Api.Application.DTOs;
using CM.Api.Application.Services;
using CM.Api.Domain.Entities;
using CM.Api.Infrastructure;
using MediatR;

namespace CM.Api.Application.Commands.Handlers;

public class CreateCardHandler : IRequestHandler<CreateCard, CardDto>
{
    private readonly AppDbContext _context;
    private readonly IPanService _panService;
    private readonly IMediator _mediator;

    public CreateCardHandler(AppDbContext context, IPanService panService, IMediator mediator)
    {
        _context = context;
        _panService = panService;
        _mediator = mediator;
    }

    public async Task<CardDto> Handle(CreateCard request, CancellationToken cancellationToken)
    {
        var pan = await _panService.Generate();
        var account = await _mediator.Send(new CreateAccount(), cancellationToken);

        var expiryDate = DateTimeOffset.UtcNow.AddYears(3).Date;

        var card = Card.Create(
            request.HolderName, pan,
            expiryDate.AddMonths(1).Subtract(new TimeSpan(0, 0, 0, 0, 1)).Date,
            account.Id);

        _context.Cards.Add(card);
        await _context.SaveChangesAsync(cancellationToken);

        return new CardDto
        {
            CardId = card.Id,
            HolderName = card.HolderName,
            PAN = card.AccountNumber,
            ExpiryDate = card.ExpiryDate,
            AccountIBAN = account.IBAN
        };
    }
}