namespace Security.Service.Domain.Services.Authenticate;

public interface IAccountAuthenticator
{
    public Task<bool> AuthenticateAsync(string name, string secret);
}