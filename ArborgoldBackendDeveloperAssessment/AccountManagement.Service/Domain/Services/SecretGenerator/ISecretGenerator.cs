namespace AccountManagement.Service.Domain.Services.SecretGenerator;

public interface ISecretGenerator<out T>
{
    public T Generate(int length);
}