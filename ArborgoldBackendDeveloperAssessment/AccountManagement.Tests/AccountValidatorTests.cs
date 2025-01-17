using AccountManagement.Service.Domain.Models;
using AccountManagement.Service.Domain.Repositories;
using AccountManagement.Service.Domain.Services.AccountValidator;
using FakeItEasy;

namespace AccountManagement.Tests;

public class AccountValidatorTests
{
    private readonly IAccountReadRepository _accountReadRepository;

    public AccountValidatorTests()
    {
        _accountReadRepository = A.Fake<IAccountReadRepository>();
    }

    [Fact]
    public async void Validate_NullAccount()
    {
        Account account = null;
        var accountValidator = new AccountValidator(_accountReadRepository);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await accountValidator.ValidateAsync(account));
    }

    [Fact]
    public async void Validate_NameIsNull()
    {
        var account = new Account();
        account.User = new User();

        var accountValidator = new AccountValidator(_accountReadRepository);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await accountValidator.ValidateAsync(account));
    }

    [Fact]
    public async void Validate_UniqueAccountName()
    {
        var account = new Account();
        account.User = new User{Name = "Test"};

        var accountValidator = new AccountValidator(_accountReadRepository);
        A.CallTo(() => _accountReadRepository.GetAccountByNameAsync(A<string>.Ignored)).Returns(account);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await accountValidator.ValidateAsync(account));
    }
}