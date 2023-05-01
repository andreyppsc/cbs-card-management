using CM.Api.Domain.Entities;
using MediatR;

namespace CM.Api.Application.Commands;

public class CreateAccount : IRequest<Account> { }