using Microsoft.EntityFrameworkCore;
using Reporting.Service.Domain.Models;

namespace Reporting.Service.Infrastructure;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}