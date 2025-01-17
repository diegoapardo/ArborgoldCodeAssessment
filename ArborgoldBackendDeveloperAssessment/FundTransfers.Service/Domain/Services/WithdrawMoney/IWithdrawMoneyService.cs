namespace FundTransfers.Service.Domain.Services.WithdrawMoney;

public interface IWithdrawMoneyService
{
    public Task WithdrawMoneyAsync(string name, decimal amount);
}