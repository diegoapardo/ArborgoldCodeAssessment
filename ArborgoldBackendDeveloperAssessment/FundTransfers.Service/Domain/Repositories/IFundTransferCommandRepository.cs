namespace FundTransfers.Service.Domain.Repositories;

public interface IFundTransferCommandRepository
{
    public Task SaveAccountBalance(string name, decimal balance);
}