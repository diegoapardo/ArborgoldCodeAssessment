using Reporting.Service.Domain.Models;

namespace Reporting.Service.Domain.Services;

public interface IAccountReportingService
{
    public Task<IList<Account>> AuditLowBalances(decimal threshold);
    public Task<Account?> ViewPoorestAccount();
}