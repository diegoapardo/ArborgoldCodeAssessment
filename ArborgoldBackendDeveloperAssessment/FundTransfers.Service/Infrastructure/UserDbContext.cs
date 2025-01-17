using FundTransfers.Service.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FundTransfers.Service.Infrastructure;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}