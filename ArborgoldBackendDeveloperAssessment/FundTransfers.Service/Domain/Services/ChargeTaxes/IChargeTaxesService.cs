namespace FundTransfers.Service.Domain.Services.ChargeTaxes;
public interface IChargeTaxesService
{
    public Task ChargeTaxesAsync(decimal taxRate);
}