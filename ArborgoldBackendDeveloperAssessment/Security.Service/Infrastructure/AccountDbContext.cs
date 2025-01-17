using Microsoft.EntityFrameworkCore;
using Security.Service.Domain.Models;

namespace Security.Service.Infrastructure;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts => Set<Account>();

}

