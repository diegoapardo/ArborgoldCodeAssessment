using FundTransfers.Service.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FundTransfers.Service.Infrastructure;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts => Set<Account>();

}

