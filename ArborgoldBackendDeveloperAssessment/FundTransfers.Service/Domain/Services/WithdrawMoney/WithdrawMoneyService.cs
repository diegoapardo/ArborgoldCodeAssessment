using FundTransfers.Service.Domain.Repositories;

namespace FundTransfers.Service.Domain.Services.WithdrawMoney;

public class WithdrawMoneyService : IWithdrawMoneyService
{
    private readonly IFundTransferReadRepository _fundTransferReadRepository;
    private readonly IFundTransferCommandRepository _fundTransferCommandRepository;

    public WithdrawMoneyService(IFundTransferReadRepository fundTransferReadRepository, IFundTransferCommandRepository fundTransferCommandRepository)
    {
        _fundTransferReadRepository = fundTransferReadRepository;
        _fundTransferCommandRepository = fundTransferCommandRepository;
    }

    public async Task WithdrawMoneyAsync(string name, decimal amount)
    {
        var balance = await _fundTransferReadRepository.GetBalanceAsync(name);

        if (amount > balance)
        {
            throw new Exception("Withdraw amount is greater than balance.");
        }

        var newBalance = balance - amount;
        await _fundTransferCommandRepository.SaveAccountBalance(name, newBalance);
    }
}