using AccountManagement.Service.Domain.Models;
using AccountManagement.Service.Domain.Services.AccountValidator;
using AccountManagement.Service.Domain.Services.SecretGenerator;

namespace AccountManagement.Service.Domain.Factories;

public class AccountFactory : IAccountFactory
{
    private const int SecretLength = 4;
    private readonly ISecretGenerator<string> _secretGenerator;

    public AccountFactory(ISecretGenerator<string> secretGenerator)
    {
        _secretGenerator = secretGenerator;
    }

    public Account CreateAccount(string name, decimal balance)
    {
        var user = User.UserFactory(name);

        return new Account
            {
                User = user,
                Balance = balance,
                Secret = _secretGenerator.Generate(SecretLength),
                Created = DateTime.UtcNow
            };
    }
}