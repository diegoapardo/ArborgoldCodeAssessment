using AccountManagement.Service.Domain.Factories;
using AccountManagement.Service.Domain.Models;
using AccountManagement.Service.Domain.Repositories;
using AccountManagement.Service.Domain.Services.AccountService;
using AccountManagement.Service.Domain.Services.AccountValidator;
using AccountManagement.Service.Domain.Services.SecretGenerator;
using FakeItEasy;

namespace AccountManagement.Tests;

public class AccountServiceTests
{
    private readonly IList<Account> _testAccounts;
    private readonly IAccountFactory _accountFactory;
    private readonly IAccountValidator _accountValidator;
    private readonly IAccountCommandRepository _accountCommandRepository;
    private readonly IAccountReadRepository _accountReadRepository;

    public AccountServiceTests()
    {
        _accountFactory = new AccountFactory(new SecretGenerator());

        _testAccounts = new List<Account>
        {
            _accountFactory.CreateAccount("Account1", 1m),
            _accountFactory.CreateAccount("Account2", 2m),
            _accountFactory.CreateAccount("Account3", 3m)
        };

        _accountValidator = A.Fake<IAccountValidator>();
        _accountCommandRepository = A.Fake<IAccountCommandRepository>();
        _accountReadRepository = A.Fake<IAccountReadRepository>();

    }

    [Fact]
    public async void AddAccountAsync_GoldenPath()
    {
        A.CallTo(() => _accountValidator.ValidateAsync(A<Account>.Ignored)).Returns(Task.CompletedTask);
        A.CallTo(() => _accountCommandRepository.AddAsync(A<Account>.Ignored)).Returns(Task.CompletedTask);

        var accountService = new AccountService(_accountFactory, _accountValidator, _accountCommandRepository, _accountReadRepository);
        await accountService.AddAccountAsync("test", 1m);

        A.CallTo(() => _accountValidator.ValidateAsync(A<Account>.Ignored)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async void ViewAllAccountsAsync_GoldenPath()
    {
        A.CallTo(() => _accountReadRepository.GetAllAccountsAsync()).Returns(_testAccounts);

        var accountService = new AccountService(_accountFactory, _accountValidator, _accountCommandRepository, _accountReadRepository);
        var accounts = await accountService.ViewAllAccountsAsync();

        A.CallTo(() => _accountReadRepository.GetAllAccountsAsync()).MustHaveHappenedOnceExactly();
        Assert.Equal(_testAccounts, accounts);
    }

    [Fact]
    public async void ViewTotalBalance_GoldenPath()
    {
        var expectedBalanceTotal = _testAccounts.Sum(a => a.Balance);

        A.CallTo(() => _accountReadRepository.GetAllAccountsAsync()).Returns(_testAccounts);

        var accountService = new AccountService(_accountFactory, _accountValidator, _accountCommandRepository, _accountReadRepository);
        var balanceTotal = await accountService.ViewTotalBalanceAsync();

        A.CallTo(() => _accountReadRepository.GetAllAccountsAsync()).MustHaveHappenedOnceExactly();
        Assert.Equal(expectedBalanceTotal, balanceTotal);
    }
}