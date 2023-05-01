using CM.Api.Application.Services;
using CM.Api.Domain.Entities;
using CM.Api.Infrastructure;
using MediatR;

namespace CM.Api.Application.Commands.Handlers;

public class CreateAccountHandler : IRequestHandler<CreateAccount, Account>
{
    private readonly AppDbContext _context;
    private readonly IIbanService _ibanService;

    public CreateAccountHandler(AppDbContext context, IIbanService ibanService)
    {
        _context = context;
        _ibanService = ibanService;
    }

    public async Task<Account> Handle(CreateAccount request, CancellationToken cancellationToken)
    {
        var iban = await _ibanService.Generate();
        var account = Account.Create("2511", iban);

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync(cancellationToken);

        return account;
    }
}