using CM.Api.Application.Services;

namespace CM.Api.Infrastructure.Services;

public class PanService : IPanService
{
    public Task<string> Generate()
    {
        var random = new Random();
        var creditCardNumber = "";
        
        creditCardNumber += random.Next(5000, 5700).ToString();
        
        for (var i = 0; i < 11; i++)
        {
            creditCardNumber += random.Next(0, 9).ToString();
        }
        
        var checksum = CalculateLuhnChecksum(creditCardNumber);
        creditCardNumber += checksum.ToString();

        return Task.FromResult(creditCardNumber);
    }
    
    private int CalculateLuhnChecksum(string number)
    {
        var sum = 0;
        var alternate = false;
        for (var i = number.Length - 1; i >= 0; i--)
        {
            var digit = int.Parse(number[i].ToString());
            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }
            sum += digit;
            alternate = !alternate;
        }
        return (10 - (sum % 10)) % 10;
    }
}