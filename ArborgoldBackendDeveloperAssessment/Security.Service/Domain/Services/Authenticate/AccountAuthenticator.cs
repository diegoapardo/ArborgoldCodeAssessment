using Security.Service.Domain.Repositories;

namespace Security.Service.Domain.Services.Authenticate;

public class AccountAuthenticator : IAccountAuthenticator
{
    private readonly IAccountAuthenticatorReadRepository _repository;

    public AccountAuthenticator(IAccountAuthenticatorReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AuthenticateAsync(string name, string secret)
    {
        var account = await _repository.GetAccountByNameAndSecretAsync(name, secret);

        return account != null;
    }
}