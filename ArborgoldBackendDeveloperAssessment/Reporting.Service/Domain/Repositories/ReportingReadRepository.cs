using Microsoft.EntityFrameworkCore;
using Reporting.Service.Domain.Models;
using Reporting.Service.Infrastructure;

namespace Reporting.Service.Domain.Repositories;

public class ReportingReadRepository : IReportingReadRepository
{
    private readonly AccountDbContext _context;

    public ReportingReadRepository(AccountDbContext context)
    {
        _context = context;
    }

    public async Task<IList<Account>> GetAllAccounts()
    {
        return await _context.Accounts.Include(account => account.User).ToListAsync();
    }
}