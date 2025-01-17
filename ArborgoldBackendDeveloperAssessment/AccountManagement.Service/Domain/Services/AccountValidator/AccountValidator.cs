using AccountManagement.Service.Domain.Models;
using AccountManagement.Service.Domain.Repositories;

namespace AccountManagement.Service.Domain.Services.AccountValidator;

public class AccountValidator : IAccountValidator
{
    private readonly IAccountReadRepository _accountReadRepository;

    public AccountValidator(IAccountReadRepository accountReadRepository)
    {
        _accountReadRepository = accountReadRepository;
    }

    public async Task ValidateAsync(Account account)
    {
        if (account?.User is null)
        {
            throw new InvalidOperationException("Error - Account is null.");
        }

        if (account.User.Name == null || account.User.Name.Equals(string.Empty))
        {
            throw new InvalidOperationException("Error - Account name is empty.");
        }

        var queriedAccount = await _accountReadRepository.GetAccountByNameAsync(account.User.Name);

        if (queriedAccount != null)
        {
            throw new InvalidOperationException("Error - Account name already exists.");
        }
    }
}