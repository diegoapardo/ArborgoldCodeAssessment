using AccountManagement.Service.Domain.Models;

namespace AccountManagement.Service.Domain.Repositories;

public interface IAccountCommandRepository
{
    public Task AddAsync(Account account);
}