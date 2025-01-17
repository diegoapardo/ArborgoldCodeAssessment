using AccountManagement.Service.Domain.Factories;
using AccountManagement.Service.Domain.Repositories;
using AccountManagement.Service.Domain.Services.AccountValidator;
using AccountManagement.Service.Domain.Services.SecretGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AccountManagement.Service.Domain.Services.AccountService;
using AccountManagement.Service.Presentation;
using ArborgoldBackendDeveloperAssessment;
using FundTransfers.Service.Domain.Repositories;
using FundTransfers.Service.Domain.Services.ChargeTaxes;
using Security.Service.Domain.Services.Authenticate;
using Security.Service.Presentation;
using FundTransfers.Service.Domain.Services.WithdrawMoney;
using FundTransfers.Service.Presentation;
using Microsoft.Extensions.Configuration;
using Reporting.Service.Domain.Repositories;
using Reporting.Service.Domain.Services;
using Reporting.Service.Presentation;
using Security.Service.Domain.Repositories;


var workingDirectory = Environment.CurrentDirectory;
var projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;

var builder = Host.CreateApplicationBuilder(args);

// DI for Account Management Service
builder.Services.AddSingleton<IAccountFactory, AccountFactory>();
builder.Services.AddScoped<IAccountCommandRepository, AccountCommandRepository>();
builder.Services.AddScoped<IAccountReadRepository, AccountReadRepository>();
builder.Services.AddTransient<IAccountValidator, AccountValidator>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ISecretGenerator<string>, SecretGenerator>();
builder.Services.AddScoped<IAccountManagementOrchestrator, AccountManagementOrchestrator>();
builder.Services.AddSingleton<BankingApp>();
builder.Services.AddDbContext<AccountManagement.Service.Infrastructure.AccountDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseSqlite($"Data Source={projectDirectory}/sqlite.db"));
builder.Services.AddDbContext<AccountManagement.Service.Infrastructure.UserDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseSqlite($"Data Source={projectDirectory}/sqlite.db"));


// DI for Security Service
builder.Services.AddScoped<IAccountAuthenticatorReadRepository, AccountAuthenticatorReadRepository>();
builder.Services.AddTransient<IAccountAuthenticator, AccountAuthenticator>();
builder.Services.AddScoped<IAuthenticatorOrchestrator, AuthenticatorOrchestrator>();
builder.Services.AddDbContext<Security.Service.Infrastructure.AccountDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseSqlite($"Data Source={projectDirectory}/sqlite.db"));
builder.Services.AddDbContext<Security.Service.Infrastructure.UserDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseSqlite($"Data Source={projectDirectory}/sqlite.db"));


// DI for Fund Transfer Service
builder.Services.AddScoped<IFundTransferCommandRepository, FundTransferCommandRepository>();
builder.Services.AddScoped<IFundTransferReadRepository, FundTransferReadRepository>();
builder.Services.AddScoped<IFundTransferCommandRepository, FundTransferCommandRepository>();
builder.Services.AddTransient<IWithdrawMoneyService, WithdrawMoneyService>();
builder.Services.AddTransient<IChargeTaxesService, ChargeTaxesService>();
builder.Services.AddScoped<IFundTransferOrchestrator, FundTransferOrchestrator>();
builder.Services.AddDbContext<FundTransfers.Service.Infrastructure.AccountDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseSqlite($"Data Source={projectDirectory}/sqlite.db"));
builder.Services.AddDbContext<FundTransfers.Service.Infrastructure.UserDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseSqlite($"Data Source={projectDirectory}/sqlite.db"));


// DI for Reporting Service
builder.Services.AddScoped<IReportingReadRepository, ReportingReadRepository>();
builder.Services.AddTransient<IAccountReportingService, AccountReportingService>();
builder.Services.AddScoped<IReportingOrchestrator, ReportingOrchestrator>();
builder.Services.AddDbContext<Reporting.Service.Infrastructure.AccountDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseSqlite($"Data Source={projectDirectory}/sqlite.db"));
builder.Services.AddDbContext<Reporting.Service.Infrastructure.UserDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseSqlite($"Data Source={projectDirectory}/sqlite.db"));

using var host = builder.Build();

RunBankingApp(host.Services);


static void RunBankingApp(IServiceProvider hostProvider)
{
    using var serviceScope = hostProvider.CreateScope();
    var provider = serviceScope.ServiceProvider;

    var bankingApp = provider.GetService<BankingApp>();
    bankingApp?.Run();
}

