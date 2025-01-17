using Reporting.Service.Domain.Models;

namespace Reporting.Service.Domain.Repositories;

public interface IReportingReadRepository
{
    public Task<IList<Account>> GetAllAccounts();
}