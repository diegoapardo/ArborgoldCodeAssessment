using Microsoft.EntityFrameworkCore;
using Security.Service.Domain.Models;
using Security.Service.Infrastructure;

namespace Security.Service.Domain.Repositories;

public class AccountAuthenticatorReadRepository : IAccountAuthenticatorReadRepository
{
    private readonly AccountDbContext _context;

    public AccountAuthenticatorReadRepository(AccountDbContext context)
    {
        _context = context;
    }

    public async Task<Account?> GetAccountByNameAndSecretAsync(string name, string secret)
    {
        return await _context.Accounts.FirstOrDefaultAsync(account =>
            account.User.Name.Equals(name) && account.Secret.Equals(secret));
    }
}