using FundTransfers.Service.Domain.Models;
using FundTransfers.Service.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FundTransfers.Service.Domain.Repositories;

public class FundTransferReadRepository : IFundTransferReadRepository
{
    private readonly AccountDbContext _context;

    public FundTransferReadRepository(AccountDbContext context)
    {
        _context = context;
    }

    public async Task<decimal> GetBalanceAsync(string name)
    {
        //TODO: Error handling
        var account = await _context.Accounts.FirstOrDefaultAsync(account => account.User.Name.Equals(name));

        return account.Balance;
    }

    public async Task<IList<Account>> GetAllAccounts()
    {
        return await _context.Accounts.Include(account => account.User).ToListAsync();
    }
}