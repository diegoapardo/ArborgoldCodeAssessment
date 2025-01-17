namespace Security.Service.Presentation;
public interface IAuthenticatorOrchestrator
{
    public Task<bool> AuthenticateAccount(string name, string secret);
}