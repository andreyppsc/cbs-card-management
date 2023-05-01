using CM.Api.Application.DTOs;
using CM.Api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CM.Api.Application.Queries.Handlers;

public class GetCardHandler : IRequestHandler<GetCard, CardDto>
{
    private readonly AppDbContext _context;

    public GetCardHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CardDto> Handle(GetCard request, CancellationToken cancellationToken)
    {
        var card = await _context.Cards.AsNoTracking().SingleAsync(c => c.Id.Equals(request.CardId), cancellationToken);
        var account = await _context.Accounts.AsNoTracking().SingleAsync(c => c.Id.Equals(card.AccountId), cancellationToken);

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