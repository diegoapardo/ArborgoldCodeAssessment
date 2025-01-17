using AccountManagement.Service.Domain.Factories;
using AccountManagement.Service.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Service.Infrastructure;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts => Set<Account>();

}

