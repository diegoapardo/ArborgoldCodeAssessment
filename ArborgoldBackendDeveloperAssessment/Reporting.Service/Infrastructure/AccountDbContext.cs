using Microsoft.EntityFrameworkCore;
using Reporting.Service.Domain.Models;

namespace Reporting.Service.Infrastructure;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts => Set<Account>();

}

