using AccountManagement.Service.Domain.Models;
using AccountManagement.Service.Infrastructure;

namespace AccountManagement.Service.Domain.Repositories;

public class AccountCommandRepository : IAccountCommandRepository
{
    private readonly AccountDbContext _context;

    public AccountCommandRepository(AccountDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
    }
}