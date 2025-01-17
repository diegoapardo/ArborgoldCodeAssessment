using AccountManagement.Service.Domain.Models;

namespace AccountManagement.Service.Domain.Services.AccountService;
public interface IAccountService
{
    public Task AddAccountAsync(string name, decimal balance);
    public Task<IList<Account>> ViewAllAccountsAsync();
    public Task<decimal> ViewTotalBalanceAsync();
}