using AccountManagement.Service.Domain.Services.SecretGenerator;

namespace AccountManagement.Tests;

public class SecretGeneratorTests
{
    [Theory]
    [InlineData(4)]
    [InlineData(3)]
    [InlineData(10)]
    public void Generate_GoldenPath(int length)
    {
        var secretGenerator = new SecretGenerator();
        var secret1 = secretGenerator.Generate(length);
        var secret2 = secretGenerator.Generate(length);

        Assert.Equal(length, secret1.Length);
        Assert.Equal(length, secret2.Length);
        Assert.NotEqual(secret1, secret2);
    }
}