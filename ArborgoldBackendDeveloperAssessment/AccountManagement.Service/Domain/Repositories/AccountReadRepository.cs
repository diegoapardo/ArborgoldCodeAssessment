
using AccountManagement.Service.Domain.Models;
using AccountManagement.Service.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Service.Domain.Repositories;

public class AccountReadRepository : IAccountReadRepository
{
    private readonly AccountDbContext _context;

    public AccountReadRepository(AccountDbContext context)
    {
        _context = context;
    }

    public async Task<IList<Account>> GetAllAccountsAsync()
    {
        return await _context.Accounts.Include(a => a.User).ToListAsync();
    }

    public async Task<Account?> GetAccountByNameAsync(string name)
    {
        return await _context.Accounts.Where(account => account.User.Name.Equals(name)).FirstOrDefaultAsync();
    }
}