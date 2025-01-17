using FundTransfers.Service.Domain.Services.ChargeTaxes;
using FundTransfers.Service.Domain.Services.WithdrawMoney;

namespace FundTransfers.Service.Presentation;

public class FundTransferOrchestrator : IFundTransferOrchestrator
{
    private readonly IWithdrawMoneyService _withdrawMoneyService;
    private readonly IChargeTaxesService _chargeTaxesService;

    public FundTransferOrchestrator(IWithdrawMoneyService withdrawMoneyService, IChargeTaxesService chargeTaxesService)
    {
        _withdrawMoneyService = withdrawMoneyService;
        _chargeTaxesService = chargeTaxesService;
    }

    public async Task<string> WithdrawMoney(string name, decimal amount)
    {
        try
        {
            await _withdrawMoneyService.WithdrawMoneyAsync(name, amount);

            return "Success - Withdrew money from account.";
        }
        catch (Exception ex)
        {
            return $"Failure - Could not withdraw money. {ex.Message}";
        }
    }

    public async Task<string> ChargeTaxes(decimal taxRate)
    {
        try
        {
            await _chargeTaxesService.ChargeTaxesAsync(taxRate);
            return $"Success - Charged all accounts a tax rate of {taxRate}";
        }
        catch (Exception ex)
        {
            return "Failure - Could not charge tax rate";
        }
    }
}