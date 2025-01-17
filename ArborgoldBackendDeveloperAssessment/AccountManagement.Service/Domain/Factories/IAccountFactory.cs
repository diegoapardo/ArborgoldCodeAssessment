using AccountManagement.Service.Domain.Models;

namespace AccountManagement.Service.Domain.Factories;

public interface IAccountFactory
{
    public Account CreateAccount(string name, decimal balance);
}