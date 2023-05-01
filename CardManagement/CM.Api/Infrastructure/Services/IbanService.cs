using System.Numerics;
using System.Text;
using CM.Api.Application.Services;

namespace CM.Api.Infrastructure.Services;

public class IbanService : IIbanService
{
    public Task<string> Generate()
    {
        const string bankIdentifier = "ROIN";
        
        var accountNumber = GenerateRandomAccountNumber();
        
        const string countryCode = "RO";
        var checkDigits = "00";
        var ibanWithoutCheckDigits = accountNumber + bankIdentifier + countryCode + checkDigits;
        var ibanWithoutCheckDigitsAsNumber = ConvertLettersToNumbers(ibanWithoutCheckDigits);
        var checkDigitsAsNumber = (98 - (ibanWithoutCheckDigitsAsNumber % 97));
        checkDigits = checkDigitsAsNumber.ToString("D2");
        
        var iban = countryCode + checkDigits + bankIdentifier + accountNumber;

        return Task.FromResult(iban);
    }
    
    private BigInteger ConvertLettersToNumbers(string input)
    {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var output = new StringBuilder(input.Length);
        foreach (var c in input)
        {
            if (char.IsLetter(c))
            {
                var letterValue = letters.IndexOf(Char.ToUpper(c)) + 10;
                output.Append(letterValue);
            }
            else
            {
                output.Append(c);
            }
        }
        return BigInteger.Parse(output.ToString());
    }
    
    private string GenerateRandomAccountNumber()
    {
        var random = new Random();
        var accountNumber = "";
        for (var i = 0; i < 16; i++)
        {
            accountNumber += random.Next(10).ToString();
        }
        return accountNumber;
    }
}