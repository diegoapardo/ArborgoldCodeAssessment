using FundTransfers.Service.Domain.Models;

namespace FundTransfers.Service.Domain.Repositories;

public interface IFundTransferReadRepository
{
    public Task<decimal> GetBalanceAsync(string name);
    public Task<IList<Account>> GetAllAccounts();
}