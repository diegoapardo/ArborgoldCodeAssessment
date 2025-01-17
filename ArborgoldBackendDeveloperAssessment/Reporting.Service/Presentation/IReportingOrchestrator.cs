namespace Reporting.Service.Presentation;

public interface IReportingOrchestrator
{
    public Task<string> AuditLowBalances(decimal threshold);
    public Task<string> ViewPoorestAccount();
}