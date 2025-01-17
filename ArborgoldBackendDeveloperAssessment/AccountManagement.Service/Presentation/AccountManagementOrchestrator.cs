using System.Globalization;
using System.Text;
using AccountManagement.Service.Domain.Models;
using AccountManagement.Service.Domain.Services.AccountService;

namespace AccountManagement.Service.Presentation;

public class AccountManagementOrchestrator : IAccountManagementOrchestrator
{
    private readonly IAccountService _accountService;

    public AccountManagementOrchestrator(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<string> AddNewAccountAsync(string name, decimal balance)
    {
        try
        {
            await _accountService.AddAccountAsync(name, balance);

            return "Success - Added new account.";
        }
        catch (Exception ex)
        {
            return $"Failure - Could not add new account. {ex.Message}";
        }
    }

    public async Task<string> ViewAllAccountsAsync()
    {
        try
        {
            var accounts = await _accountService.ViewAllAccountsAsync();

            var stringBuilder = new StringBuilder();

            foreach (var account in accounts)
            {
                var accountString = $"{account.User.Name} \t {account.Balance} \t\t {account.Created} \n";
                stringBuilder.Append(accountString);
            }

            return stringBuilder.ToString();
        }
        catch (Exception ex)
        {
            return $"Failure - Could not get all accounts. {ex.Message}";
        }
    }

    public async Task<string> ViewTotalBalanceAsync()
    {
        try
        {
            var balance = await _accountService.ViewTotalBalanceAsync();
            return balance.ToString(CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
            return $"Failure - Could not get total balance. {ex.Message}";
        }
    }
}