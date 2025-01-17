using AccountManagement.Service.Presentation;
using FundTransfers.Service.Presentation;
using Security.Service.Presentation;
using Reporting.Service.Presentation;
using Decimal = System.Decimal;

namespace ArborgoldBackendDeveloperAssessment;

internal enum UserType
{
    BankManager,
    AccountUser,
    Invalid
}

public class BankingApp
{
    private UserType _userType = UserType.Invalid;
    private bool _runFlag = true;
    private readonly IAccountManagementOrchestrator _accountManagementOrchestrator;
    private readonly IAuthenticatorOrchestrator _authenticatorOrchestrator;
    private readonly IFundTransferOrchestrator _fundTransferOrchestrator;
    private readonly IReportingOrchestrator _reportingOrchestrator;

    public BankingApp(IAccountManagementOrchestrator accountManagementOrchestrator, IAuthenticatorOrchestrator authenticatorOrchestrator, IFundTransferOrchestrator fundTransferOrchestrator, IReportingOrchestrator reportingOrchestrator)
    {
        _accountManagementOrchestrator = accountManagementOrchestrator;
        _authenticatorOrchestrator = authenticatorOrchestrator;
        _fundTransferOrchestrator = fundTransferOrchestrator;
        _reportingOrchestrator = reportingOrchestrator;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the Banking App");

        while (_runFlag)
        {
            RunUserType();
        }
    }

    private void RunUserType()
    {
        Console.WriteLine("Are you a Bank Manager (M) or Account User (A)?");
        var userType = Console.ReadLine();

        if (userType?.ToUpper() is "M")
        {
            _userType = UserType.BankManager;
            Console.WriteLine("You selected Bank Manager.");
            RunBankManager();

        }
        else if (userType?.ToUpper() is "A")
        {
            _userType = UserType.AccountUser;
            Console.WriteLine("You selected Account User.");
            RunAccountUser();
        }
        else
        {
            Console.WriteLine("Invalid selection. Please select Bank Manager (M) or Account User (A).");
        }
    }

    private void RunAccountUser()
    {
        var accountUserFlag = false;

        Console.WriteLine("Please enter account name");
        var accountName = Console.ReadLine();
        Console.WriteLine("Please enter account secret");
        var accountSecret = Console.ReadLine();

        var isAuthenticated = _authenticatorOrchestrator.AuthenticateAccount(accountName, accountSecret).Result;

        if (isAuthenticated)
        {
            accountUserFlag = true;
            Console.WriteLine($"Welcome {accountName} to your account.");
        }
        else
        {
            Console.WriteLine("Wrong credentials.");
        }
        while (accountUserFlag)
        {
            Console.WriteLine("Please enter the number from the menu below:");
            Console.WriteLine("1. Withdraw Money");
            Console.WriteLine("2. Exit Account User Mode");

            var userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    WithdrawMoney(accountName);
                    break;
                case "2":
                    accountUserFlag = false;
                    break;
            }
        }
    }

    private void WithdrawMoney(string name)
    {
        Console.WriteLine("Please enter amount to withdraw");
        var amountInput = Console.ReadLine();

        if (Decimal.TryParse(amountInput, out var amount))
        {
            var message = _fundTransferOrchestrator.WithdrawMoney(name, amount).Result;
            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine("Invalid withdraw amount format.");
        }
    }

    private void RunBankManager()
    {
        var bankManagerFlag = true;

        while (bankManagerFlag)
        {
            Console.WriteLine("Please enter the number from the menu below:");
            Console.WriteLine("1. Add New Accounts");
            Console.WriteLine("2. View All Accounts");
            Console.WriteLine("3. View Total Balance");
            Console.WriteLine("4. Charge Taxes");
            Console.WriteLine("5. Audit Low Balances");
            Console.WriteLine("6. View Poorest Account");
            Console.WriteLine("7. Exit Bank Manager Mode");


            var userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    AddNewAccount();
                    break;
                case "2":
                    ViewAllAccounts();
                    break;
                case "3":
                    ViewTotalBalance();
                    break;
                case "4":
                    ChargeTaxes();
                    break;
                case "5":
                    AuditLowBalances();
                    break;
                case "6":
                    ViewPoorestAccount();
                    break;
                case "7":
                    bankManagerFlag = false;
                    break;
            }
        }

    }

    private void ViewPoorestAccount()
    {
        var poorestAccountInfo = _reportingOrchestrator.ViewPoorestAccount().Result;
        Console.WriteLine($"Poorest account info: {poorestAccountInfo}");
    }

    private void AuditLowBalances()
    {
        Console.WriteLine("Please enter low balance threshold amount (Ex: 54.00, 1230.00, 1.55)");
        var thresholdInput = Console.ReadLine();

        if (Decimal.TryParse(thresholdInput, out var threshold))
        {
            var message = _reportingOrchestrator.AuditLowBalances(threshold).Result;
            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine("Invalid low balance threshold format.");
        }
    }

    private void ChargeTaxes()
    {
        Console.WriteLine("Please enter tax rate amount (Ex: 7.00, 100.00, 5.55)");
        var taxRateInput = Console.ReadLine();

        if (Decimal.TryParse(taxRateInput, out var taxRate))
        {
            var message = _fundTransferOrchestrator.ChargeTaxes(taxRate).Result;
            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine("Invalid tax rate format.");
        }
    }

    private void AddNewAccount()
    {
        Console.WriteLine("Please enter the account name");
        var accountName = Console.ReadLine();

        Console.WriteLine("Please enter the account balance as a decimal (Ex: 2.00, 0.00, 134.23)");
        var accountBalance = Console.ReadLine();

        if (Decimal.TryParse(accountBalance, out var balance))
        {
            var message = _accountManagementOrchestrator.AddNewAccountAsync(accountName, balance).Result;
            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine("Invalid balance format.");
        }
    }

    private void ViewAllAccounts()
    {
        var formattedAccounts = _accountManagementOrchestrator.ViewAllAccountsAsync().Result;
        Console.WriteLine(formattedAccounts);
    }

    private void ViewTotalBalance()
    {
        var totalBalance = _accountManagementOrchestrator.ViewTotalBalanceAsync().Result;
        Console.WriteLine(totalBalance);
    }
}

