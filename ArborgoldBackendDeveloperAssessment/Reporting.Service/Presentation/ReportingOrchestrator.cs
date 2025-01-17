using System.Text;
using Reporting.Service.Domain.Services;

namespace Reporting.Service.Presentation;

public class ReportingOrchestrator : IReportingOrchestrator
{
    private readonly IAccountReportingService _reportingService;

    public ReportingOrchestrator(IAccountReportingService reportingService)
    {
        _reportingService = reportingService;
    }

    public async Task<string> AuditLowBalances(decimal threshold)
    {
        try
        {
            var lowBalanceAccounts = await _reportingService.AuditLowBalances(threshold);

            var stringBuilder = new StringBuilder();

            foreach (var account in lowBalanceAccounts)
            {
                var lowBalanceAccountString = $"{account.User.Name} \t {account.Balance} \n";
                stringBuilder.Append(lowBalanceAccountString);
            }

            return stringBuilder.ToString();
        }
        catch (Exception ex)
        {
            return "Failure - Could not get low balance";
        }
    }

    public async Task<string> ViewPoorestAccount()
    {
        var account = await _reportingService.ViewPoorestAccount();

        return account == null ? "No accounts found." : $"{account.User.Name} \t {account.Balance}";
    }
}