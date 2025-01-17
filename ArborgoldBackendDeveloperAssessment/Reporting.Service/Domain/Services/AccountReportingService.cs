using Reporting.Service.Domain.Models;
using Reporting.Service.Domain.Repositories;

namespace Reporting.Service.Domain.Services;

public class AccountReportingService : IAccountReportingService
{
    private readonly IReportingReadRepository _reportingReadRepository;

    public AccountReportingService(IReportingReadRepository reportingReadRepository)
    {
        _reportingReadRepository = reportingReadRepository;
    }

    public async Task<IList<Account>> AuditLowBalances(decimal threshold)
    {
        var accounts = await _reportingReadRepository.GetAllAccounts();

        return accounts.Where(account => account.Balance <= threshold).ToList();
    }

    public async Task<Account?> ViewPoorestAccount()
    {
        var accounts = await _reportingReadRepository.GetAllAccounts();
        var poorestAccount = accounts.MinBy(account => account.Balance);

        return poorestAccount;
    }
}