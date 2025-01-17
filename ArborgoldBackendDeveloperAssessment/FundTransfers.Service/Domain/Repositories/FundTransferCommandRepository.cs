using FundTransfers.Service.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FundTransfers.Service.Domain.Repositories;

public class FundTransferCommandRepository : IFundTransferCommandRepository
{
    private readonly AccountDbContext _context;

    public FundTransferCommandRepository(AccountDbContext context)
    {
        _context = context;
    }

    public async Task SaveAccountBalance(string name, decimal balance)
    {
        //TODO: Error handling
        var account = await _context.Accounts.Where(account => account.User.Name.Equals(name)).FirstOrDefaultAsync();
        account.Balance = balance;

        _context.Update(account);
        await _context.SaveChangesAsync();
    }
}