using AccountManagement.Service.Domain.Models;

namespace AccountManagement.Service.Domain.Repositories;

public interface IAccountReadRepository
{
    public Task<IList<Account>> GetAllAccountsAsync();
    public Task<Account?> GetAccountByNameAsync(string name);
}