using CM.Api.Application.DTOs;
using CM.Api.Domain.Entities;
using MediatR;

namespace CM.Api.Application.Commands;

public class CreateCard : IRequest<CardDto>
{
    public string HolderName { get; set; } = default!;
}