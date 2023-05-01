namespace CM.Api.Application.DTOs;

public class CardDto
{
    public Guid CardId { get; set; }
    public string HolderName { get; set; } = default!;
    // ReSharper disable once InconsistentNaming
    public string PAN { get; set; } = default!;
    public DateTime ExpiryDate { get; set; }
    // ReSharper disable once InconsistentNaming
    public string? AccountIBAN { get; set; }
}