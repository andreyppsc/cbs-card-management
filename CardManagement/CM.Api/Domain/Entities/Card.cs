namespace CM.Api.Domain.Entities;

public sealed class Card : BaseEntity
{
    public string HolderName { get; private set; } = default!;
    public string AccountNumber { get; private set; } = default!;
    public DateTime ExpiryDate { get; private set; }
    public Guid? AccountId { get; private set; }
    
    private Card() { }

    private Card(string holderName, string accountNumber, DateTime expiryDate, Guid? accountId)
    {
        Id = Guid.NewGuid();
        HolderName = holderName;
        AccountNumber = accountNumber;
        ExpiryDate = expiryDate;
        AccountId = accountId;
    }

    public static Card Create(string holderName, string accountNumber, DateTime expiryDate, Guid? accountId)
        => new(holderName, accountNumber, expiryDate, accountId);

    public void SetAccount(Guid accountId)
    {
        AccountId = accountId;
    }
}