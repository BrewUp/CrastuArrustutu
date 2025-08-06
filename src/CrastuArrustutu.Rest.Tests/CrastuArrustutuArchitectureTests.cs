using Microsoft.VisualStudio.TestPlatform.TestHost;
using NetArchTest.Rules;

namespace CrastuArrustutu.Rest.Tests;

public class CrastuArrustutuArchitectureTests
{
    [Fact]
    public void Should_CrastuArrustutuArchitecture_BeCompliant()
    {
        var types = Types.InAssembly(typeof(Program).Assembly);

        var forbiddenAssemblies = new List<string>
        {
            "CrastuArrustutu.Carnizzaro.Domain",
            "CrastuArrustutu.Carnizzaro.Entities",
            "CrastuArrustutu.Carnizzaro.Infrastructure",
            "CrastuArrustutu.Carnizzaro.ReadModel",
            "CrastuArrustutu.Carnizzaro.SharedKernel",
            
            "CrastuArrustutu.Tanura.Domain",
            "CrastuArrustutu.Tanura.Entities",
            "CrastuArrustutu.Tanura.Infrastructure",
            "CrastuArrustutu.Tanura.ReadModel",
            "CrastuArrustutu.Tanura.SharedKernel"
        };
        
        var result = types
            .ShouldNot()
            .HaveDependencyOnAny(forbiddenAssemblies.ToArray())
            .GetResult()
            .IsSuccessful;

        Assert.True(result);
    }
}