using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Service.Domain.Models;

namespace AccountManagement.Service.Domain.Services.AccountValidator;

public interface IAccountValidator
{
    public Task ValidateAsync(Account account);
}