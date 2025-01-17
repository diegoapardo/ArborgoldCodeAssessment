using FundTransfers.Service.Domain.Repositories;

namespace FundTransfers.Service.Domain.Services.ChargeTaxes;

public class ChargeTaxesService : IChargeTaxesService
{
    private readonly IFundTransferReadRepository _readRepository;
    private readonly IFundTransferCommandRepository _commandRepository;

    public ChargeTaxesService(IFundTransferReadRepository readRepository, IFundTransferCommandRepository commandRepository)
    {
        _readRepository = readRepository;
        _commandRepository = commandRepository;
    }

    public async Task ChargeTaxesAsync(decimal taxRate)
    {
        var accounts = await _readRepository.GetAllAccounts();

        foreach (var account in accounts)
        {
            var balanceAfterTaxCharge = account.Balance * ((100.0m - taxRate) / 100);
            if (balanceAfterTaxCharge < 0)
            {
                balanceAfterTaxCharge = 0.00m;
            }

            await _commandRepository.SaveAccountBalance(account.User.Name, Math.Round(balanceAfterTaxCharge, 2));
        }
    }
}