using AccountManagement.Service.Domain.Factories;
using AccountManagement.Service.Domain.Repositories;
using AccountManagement.Service.Domain.Services.AccountValidator;
using System.Text;
using System;
using AccountManagement.Service.Domain.Models;

namespace AccountManagement.Service.Domain.Services.AccountService;

public class AccountService : IAccountService
{
    private readonly IAccountFactory _accountFactory;
    private readonly IAccountValidator _accountValidator;
    private readonly IAccountCommandRepository _accountCommandRepository;
    private readonly IAccountReadRepository _accountReadRepository;

    public AccountService(IAccountFactory accountFactory, IAccountValidator accountValidator, IAccountCommandRepository accountCommandRepository, IAccountReadRepository accountReadRepository)
    {
        _accountFactory = accountFactory;
        _accountValidator = accountValidator;
        _accountCommandRepository = accountCommandRepository;
        _accountReadRepository = accountReadRepository;
    }

    public async Task AddAccountAsync(string name, decimal balance)
    {
        var account = _accountFactory.CreateAccount(name, balance);

        await _accountValidator.ValidateAsync(account);

        try
        {
            await _accountCommandRepository.AddAsync(account);
        }
        catch (Exception)
        {
            throw new Exception("Error - Could not add account.");
        }
    }

    public async Task<IList<Account>> ViewAllAccountsAsync()
    {
        try
        {
            return await _accountReadRepository.GetAllAccountsAsync();
        }
        catch (Exception)
        {
            throw new Exception("Error - Could not get all accounts.");
        }
    }

    public async Task<decimal> ViewTotalBalanceAsync()
    {
        try
        {
            var accounts = await _accountReadRepository.GetAllAccountsAsync();

            return accounts.Sum(account => account.Balance);
        }
        catch (Exception)
        {
            throw new Exception("Error - Could get total balance.");
        }
    }
}