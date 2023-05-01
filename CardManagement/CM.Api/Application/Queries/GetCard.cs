using CM.Api.Application.DTOs;
using MediatR;

namespace CM.Api.Application.Queries;

public class GetCard : IRequest<CardDto>
{
    public Guid CardId { get; }

    public GetCard(Guid cardId)
    {
        CardId = cardId;
    }
}