namespace FundTransfers.Service.Presentation;

public interface IFundTransferOrchestrator
{
    public Task<string> WithdrawMoney(string name, decimal amount);
    public Task<string> ChargeTaxes(decimal taxRate);
}