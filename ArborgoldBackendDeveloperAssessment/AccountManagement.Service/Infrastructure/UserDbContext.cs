﻿using AccountManagement.Service.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Service.Infrastructure;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}