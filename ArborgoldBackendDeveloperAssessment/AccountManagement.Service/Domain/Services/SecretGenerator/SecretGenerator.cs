using System.Text;

namespace AccountManagement.Service.Domain.Services.SecretGenerator;
public class SecretGenerator : ISecretGenerator<string>
{
    private readonly Random _random;

    public SecretGenerator()
    {
        _random = new Random();
    }

    public string Generate(int length)
    {
        const string digitPool = "0123456789";
        var stringBuilder = new StringBuilder();
        
        for (var i = 0; i < length; i++)
        {
            var digit = digitPool[_random.Next(0, digitPool.Length)];
            stringBuilder.Append(digit);
        }

        return stringBuilder.ToString();
    }
}