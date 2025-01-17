using Security.Service.Domain.Models;

namespace Security.Service.Domain.Repositories;

public interface IAccountAuthenticatorReadRepository
{
    public Task<Account?> GetAccountByNameAndSecretAsync(string name, string secret);
}