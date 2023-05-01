namespace CM.Api.Domain.Entities;

public sealed class Account : BaseEntity
{
    public string AccountCode { get; private set; } = default!;
    // ReSharper disable once InconsistentNaming
    public string IBAN { get; private set; } = default!;

    private Account() { }

    private Account(string accountCode, string iban)
    {
        Id = Guid.NewGuid();
        AccountCode = accountCode;
        IBAN = iban;
    }

    public static Account Create(string accountCode, string iban)
        => new(accountCode, iban);
}