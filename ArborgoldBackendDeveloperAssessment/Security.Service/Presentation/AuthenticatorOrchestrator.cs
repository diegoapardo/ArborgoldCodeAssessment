using Security.Service.Domain.Services.Authenticate;

namespace Security.Service.Presentation;

public class AuthenticatorOrchestrator : IAuthenticatorOrchestrator
{
    private readonly IAccountAuthenticator _authenticator;

    public AuthenticatorOrchestrator(IAccountAuthenticator authenticator)
    {
        _authenticator = authenticator;
    }

    public async Task<bool> AuthenticateAccount(string name, string secret)
    {
        return await _authenticator.AuthenticateAsync(name, secret);
    }
}