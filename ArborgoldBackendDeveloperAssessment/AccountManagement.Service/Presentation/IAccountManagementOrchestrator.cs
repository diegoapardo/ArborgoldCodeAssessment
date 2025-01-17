using AccountManagement.Service.Domain.Models;

namespace AccountManagement.Service.Presentation;

public interface IAccountManagementOrchestrator
{
    public Task<string> AddNewAccountAsync(string name, decimal balance);
    public Task<string> ViewAllAccountsAsync();
    public Task<string> ViewTotalBalanceAsync();
}